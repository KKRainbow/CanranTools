using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class ReportToChart
    {
        public delegate string[] RowFilter(string[] row);
        PowerPoint.Application ppt = null;
        string tmplPPTFilename = "Resources/tmpl.pptx";
        public ReportToChart(string filename = "D:/粲然的程序/测试/地区品牌酸奶得失.pptx")
        {
        }

        private void ReplaceTextInSlide(PowerPoint.Slide slide, string from, string to)
        {
            foreach (PowerPoint.Shape shape in slide.Shapes)
            {
                PowerPoint.TextFrame frame = shape.TextFrame;
                if (frame == null || frame.HasText == Office.MsoTriState.msoFalse)
                {
                    continue;
                }
                string text = frame.TextRange.Text;
                if (text.Length == 0)
                {
                    continue;
                }
                text = text.Replace(from, to);
                frame.TextRange.Text = text;
                frame.TextRange.Font.Name = "微软雅黑";
            }
        }
        public void Output(ShiftingReport report, string filename)
        {
            ppt = new PowerPoint.Application();
            ppt.Visible = Office.MsoTriState.msoTrue;
            PowerPoint.Presentation targetPres = ppt.Presentations.Add();
            targetPres.SaveAs(filename);
            targetPres.PageSetup.SlideSize = (PowerPoint.PpSlideSizeType.ppSlideSizeOnScreen);
            
            int index = 0;
            foreach (string region in report.Regions)
            {
                List<ReportTable> tables = (from r in report.ReportTables
                                           where r.region == region
                                           select r).ToList();
                List<string> hint = new List<string>()
                {
                    "光明畅优","光明健能","光明E+", "蒙牛", "伊利",
                };
                tables.Sort(new Comparison<ReportTable>((x, y) =>
                {
                    int xidx = hint.FindIndex(s => s.Equals(x.vendor));
                    int yidx = hint.FindIndex(s => s.Equals(y.vendor));
                    if (xidx < 0)
                    {
                        xidx = hint.Count;
                        hint.Add(x.vendor);
                    }
                    if (yidx < 0)
                    {
                        yidx = hint.Count;
                        hint.Add(y.vendor);
                    }
                    return xidx > yidx ? 1 : -1;
                }));
                foreach (ReportTable table in tables)
                {
                    targetPres.Slides.InsertFromFile(tmplPPTFilename, index * 2, 1, 2);

                    PowerPoint.Slide slideText = targetPres.Slides[index * 2 + 1];
                    PowerPoint.Slide slideChart = targetPres.Slides[index * 2 + 2];

                    ReplaceTextInSlide(slideText, "{region}", table.region);
                    ReplaceTextInSlide(slideText, "{vendor}", table.vendor);                   
                    ReplaceTextInSlide(slideChart, "{region}", table.region);
                    ReplaceTextInSlide(slideChart, "{vendor}", table.vendor);

                    BuildChart(table, slideChart.SlideNumber, 2, row =>
                    {
                        Dictionary<string, string> dict = new Dictionary<string, string>()
                        {
                                {"shiftingtotal", "品牌转换"},
                                {"retainedbuyers", "原有消费者购买增加/减少"},
                                {"new/lostbuyers", "购买清单中增加/删除品牌"},
                                {"nonbuyers", "新增/流失品类消费者"},
                        };
                        string key = row[0].Trim().Replace(" ", "").ToLower();
                        string value = null;
                        if (dict.TryGetValue(key, out value))
                        {
                            string[] newrow = new string[row.Length];
                            Array.Copy(row, newrow, row.Length);
                            newrow[0] = value;
                            return newrow;
                        }
                        return null;
                    });

                    BuildChart(table, slideChart.SlideNumber, 4, row =>
                    {
                        string key = row[0].Trim().Replace(" ", "");
                        Regex cn = new Regex("[\u4e00-\u9fa5]+");
                        if (cn.IsMatch(key))
                        {
                            string[] newrow = new string[row.Length];
                            Array.Copy(row, newrow, row.Length);
                            newrow[0] = key;
                            return newrow;
                        }
                        return null;
                    });
                    targetPres.Save();
                    index += 1;
                }
            }
        }

        public Task<int> OutputAsync(ShiftingReport report, string filename)
        {
            return Task.Run<int>(
                () =>
                {
                    Output(report, filename);
                    return 1;
                });
        }

        private PowerPoint.Chart BuildChart(ReportTable table, int page, int chartid, RowFilter filter)
        {
            PowerPoint.Slide slide = ppt.ActivePresentation.Slides[page];
            PowerPoint.Chart chart = slide.Shapes[chartid].Chart;
            chart.ChartData.Activate();
            Excel.Workbook book = chart.ChartData.Workbook;
            Excel.Worksheet sheet = book.Worksheets[1];

            //清空现有的数据
            sheet.Cells.Clear();


            int insertRow = 0;
            string[,] ta = new string[table.dataArray.Length, table.dataArray[0].Length];
            for (int i = 0; i < table.dataArray.Length; i++)
            {
                string[] row = table.dataArray[i];
                string[] filteredRow = i == 0 ? row : filter(row);
                if (filteredRow != null)
                {
                    for (int j = 0; j < filteredRow.Length; j++)
                    {
//                        ta[insertRow, j] = filteredRow[j];
                        sheet.Cells[insertRow + 1, j + 1].Value = filteredRow[j];
                    }
                    insertRow++;
                }
            }
            Excel.Range tableRange =
                sheet.Range[sheet.Cells[1, 1],
                            sheet.Cells[insertRow, table.dataArray[0].Length]];
            //tableRange.Value = ta;

            string addr = tableRange.Address;
            chart.SetSourceData(sheet.Name + "!" + tableRange.Address, PowerPoint.XlRowCol.xlRows);

            book.Close();
            return chart;
        }

        public void TestObjectId(int id)
        {
            PowerPoint.Slide slide = ppt.ActiveWindow.View.Slide;
            PowerPoint.Shape shape = slide.Shapes[id];
            if (shape != null)
                shape.Select();
        }
        
        ~ReportToChart()
        {
            /*
            if (ppt != null)
                ppt.Quit();
                */
        }
    }
}

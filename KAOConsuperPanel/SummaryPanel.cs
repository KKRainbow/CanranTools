using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1.KAOConsuperPanel
{
    using System.IO;
    using System.Windows.Forms;
    using Table = List<string[]>;
    class SummaryPanel
    {
        string city;
        string yearStr;
        int year;
        Table tableData= new Table();


        public static void ParseTable(Excel.Range startYearCell, SummaryPanel panel)
        {
            string yearStr = startYearCell.Value.ToString();
            int year;
            if (!int.TryParse(yearStr, out year))
            {
                throw new Exception("Unkonw year string yearStr in cell " + startYearCell.Address);
            }
            panel.year = year;
            panel.yearStr = yearStr;

            Excel.Range lefttop = startYearCell.End[Excel.XlDirection.xlDown];
            Excel.Range righttop = lefttop.End[Excel.XlDirection.xlToRight];

            int colStart = lefttop.Column;
            int colEnd = righttop.Column;
            int rowStart = lefttop.Row;
            int rowEnd = lefttop.Worksheet.UsedRange.Rows.Count;
            int cols = colEnd - colStart + 1, rows = rowEnd - rowStart + 1;

            if (cols > 100 || cols < 2 || rows < 2)
            {
                throw new Exception("表格大小不合理，请检查表的格式");
            }

            Table res = new Table();
            for (int row = 0; row < rows; row++)
            {
                Excel.Range rowBegin = lefttop.Offset[row, 0];
                if (rowBegin.Value == null || (rowBegin.Value.ToString() as string).Trim().Length == 0)
                {
                    //该行为空
                    continue;
                }
                string[] rowData = new string[cols];
                for (int col = 0; col < cols; col++)
                {
                    rowData[col] = rowBegin.Offset[0, col].Value.ToString();
                }
                res.Add(rowData);
            }
            panel.tableData = res;
        }
        public static List<SummaryPanel> ReadSummaryPanels(Excel.Application app, string filename)
        {
            List<SummaryPanel> res = new List<SummaryPanel>();

            Excel.Workbook workbook = app.Workbooks.Open(filename, ReadOnly: true);

            Excel.Worksheet sheet = null;
            foreach (Excel.Worksheet s in workbook.Sheets)
            {
                if (s.Name == "summary")
                    sheet = s;
            }
            if (sheet == null)
            {
                workbook.Close(false);
                throw new Exception("Cannot find sheet : summary");
            }

            Excel.Range cityStartCell = sheet.Cells[1, 1];
            while (cityStartCell.Column <= sheet.UsedRange.Columns.Count)
            {
                SummaryPanel panel = new SummaryPanel();
                string strWithCity = cityStartCell.Value.ToString();
                foreach (string city in KAO.citys)
                {
                    if (strWithCity.Contains(city))
                    {
                        panel.city = city;
                    }
                }
                if (panel.city.Length == 0)
                {
                    workbook.Close(false);
                    throw new Exception("表格格式不正确，表格名称应该包括中文城市名。:" + strWithCity);
                }
                Excel.Range yearCell = cityStartCell.Offset[1, 1];
                ParseTable(yearCell, panel);
                res.Add(panel);
                cityStartCell = cityStartCell.End[Excel.XlDirection.xlToRight];
            }
            return res;
        }

        public static async Task<List<SummaryPanel>> ReadSummaryPanelsAsync(Excel.Application app, string filename)
        {
            return await Task.Run<List<SummaryPanel>>(
                () =>
                {
                    return ReadSummaryPanels(app, filename);
                }
                );
        }

        public static void CopyToSummaryPanelExcel(Excel.Application app, List<SummaryPanel> panelList, string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("File " + fileName + " not exists");
            }
            Excel.Workbook workbook = app.Workbooks.Open(fileName);

            Excel.Worksheet sheet = null;
            foreach (Excel.Worksheet s in workbook.Sheets)
            {
                if (s.Name == "sanitary")
                    sheet = s;
            }
            if (sheet == null)
            {
                workbook.Close(false);
                throw new Exception("Cannot find sheet : sanitary");
            }

            Excel.Range cityColumn = sheet.Cells[1, 1].EntireColumn;
            Excel.Range yearRow =  sheet.Cells[1, 3].End[Excel.XlDirection.xlDown].EntireRow;
            yearRow.Select();
            foreach (SummaryPanel sp in panelList)
            {
                var cityPinyin = KAO.cityTable.FirstOrDefault(x => x.Value == sp.city).Key.ToLower();
                Excel.Range cityCell = cityColumn.Find(cityPinyin,
                    Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
                    Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlNext,
                    false, Type.Missing, Type.Missing);
                Excel.Range yearCell = yearRow.Find(sp.yearStr,
                    Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
                    Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext,
                    false, Type.Missing, Type.Missing);
                if (cityCell == null)
                {
                    throw new Exception(string.Format("Cannot find city {0}{1}", sp.city, cityPinyin));
                }
                if (yearCell == null)
                {
                    throw new Exception(string.Format("Cannot find year {0}", sp.yearStr));
                }
                Excel.Range pasteStartCell = sheet.Cells[cityCell.Row + 2, yearCell.Column];
                for (int row = 0; row < sp.tableData.Count; row++)
                {
                    for (int col = 0; col < sp.tableData[row].Length; col++)
                    {
                        pasteStartCell.Offset[row, col].Value = sp.tableData[row][col];
                    }
                }
            }
        }
        public static async Task<int> CopyToSummaryPanelExcelAsync(Excel.Application app, List<SummaryPanel> panelList, string dirName)
        {
            return await Task.Run<int>(
                () =>
                {
                    CopyToSummaryPanelExcel(app, panelList, dirName);
                    return 1;
                }
                );
        }
    }
}

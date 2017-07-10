using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.KAOConsuperPanel
{
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using TableTuple = Tuple<int, Excel.Range, string[][]>;
    class ConsumerPanel
    {
        string city;
        List<TableTuple> tableDataList = new List<TableTuple>();

        public static TableTuple ParseTable(Excel.Range startYearCell)
        {
            string yearStr = "a";
            if (startYearCell.Value != null)
                yearStr = startYearCell.Value.ToString();
            int year;
            if (!int.TryParse(yearStr, out year))
            {
                throw new Exception("Consumer: Unkonw year string yearStr in cell " + startYearCell.Address);
            }

            Excel.Range lefttop = startYearCell.Offset[1, 0];
            Excel.Range rightbottom = lefttop.End[Excel.XlDirection.xlDown].End[Excel.XlDirection.xlToRight];
            int cols = rightbottom.Column - lefttop.Column + 1;
            int rows = rightbottom.Row - lefttop.Row + 1;

            if (cols > 100 || cols < 2 || rows < 2)
            {
                return null;
            }

            Excel.Range range = startYearCell.Worksheet.Range[lefttop, rightbottom];
            string[][] data = new string[rows][];
            var values = range.Value;
            for (int x = 0; x < rows; x++)
            {
                data[x] = new string[cols];
                for (int y = 0; y < cols; y++)
                {
                    data[x][y] = values[x + 1, y + 1].ToString();
                }
                if (x == 0 && data[x].All(m => m.Trim() == "100"))
                {
                    data[x] = Enumerable.Repeat<string>("1", cols).ToArray();
                    for (int y = 0; y < cols; y++)
                    {
                        range.Cells[x + 1, y + 1].Value = "1";
                    }
                }
            }
            Trace.TraceInformation("Consumer table year is {0}, table is {1}", year, data.ToString());
            return new TableTuple(year, range, data);
        }
        public static List<ConsumerPanel> ReadConsumerPanels(Excel.Application app, string filename)
        {
            List<ConsumerPanel> res = new List<ConsumerPanel>();

            Excel.Workbook workbook = app.Workbooks.Open(filename, ReadOnly: true);
            foreach (string city in KAO.citys)
            {
                Excel.Worksheet sheet = null;
                foreach (Excel.Worksheet s in workbook.Sheets)
                {
                    if (s.Name == city)
                        sheet = s;
                }
                if (sheet == null)
                    continue;
                ConsumerPanel panel = new ConsumerPanel();
                panel.city = city;

                Excel.Range startCell = sheet.Cells[1, 1];
                while (startCell.Column <= sheet.UsedRange.Columns.Count)
                {
                    Excel.Range yearCell = startCell.Offset[2, 1];
                    panel.tableDataList.Add(ConsumerPanel.ParseTable(yearCell));
                    startCell = startCell.End[Excel.XlDirection.xlToRight];
                }
                res.Add(panel);
            }
            return res;
        }

        public static async Task<List<ConsumerPanel>> ReadConsumerPanelsAsync(Excel.Application app, string filename)
        {
            return await Task.Run<List<ConsumerPanel>>(
                () =>
                {
                    return ReadConsumerPanels(app, filename);
                }
                );
        }

        public static void CopyToConsumerPanelExcel(Excel.Application app, List<ConsumerPanel> panelList, string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                throw new Exception("Dir " + dirName + " not exists");
            }
            string[] entries = Directory.GetFileSystemEntries(dirName);
            foreach (string entry in entries)
            {
                string filename = Path.GetFileName(entry);
                char[] delims = { '.', '-' };
                string city = filename.Split(delims)[2];
                if (!KAO.cityTable.TryGetValue(city.ToLower(), out city))
                {
                    throw new Exception("Can not determine city :" + filename);
                }

                ConsumerPanel curPanel = null;
                foreach (ConsumerPanel p in panelList)
                {
                    if (p.city == city)
                    {
                        curPanel = p;
                    }
                }
                if (curPanel == null)
                {
                    throw new Exception("Cannot find panel of city " + city);
                }

                Excel.Workbook book = app.Workbooks.Open(entry, ReadOnly: false);
                if (curPanel.tableDataList.Count != book.Sheets.Count)
                {
                    throw new Exception("Panel table List count not equal to sheets count");
                }

                int idx = 0;
                foreach (Excel.Worksheet curSheet in book.Sheets)
                {
                    Trace.TraceInformation("Copying to {0}:{1}", book.Name, curSheet.Name);
                    TableTuple curTuple = curPanel.tableDataList[idx++];
                    Excel.Range startYearRange = curSheet.UsedRange.Find(curTuple.Item1.ToString(),
                        Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
                        Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext,
                        false, Type.Missing, Type.Missing);
                    string startYearStr = startYearRange.Value.ToString();
                    int startYear;
                    if (! int.TryParse(startYearStr, out startYear) || startYear != curTuple.Item1)
                    {
                        throw new Exception("Can not find a place to paste with year " + startYearStr);
                    }

                    Excel.Range startCell = startYearRange.End[Excel.XlDirection.xlDown];
                    Excel.Range endCell = startCell.Offset[curTuple.Item2.Rows.Count, curTuple.Item2.Columns.Count];
                    Excel.Range pasteRange = curSheet.Range[startCell, endCell];
                    Excel.Range copyRange = curTuple.Item2;

                    copyRange.Copy(Type.Missing);
                    pasteRange.PasteSpecial(Excel.XlPasteType.xlPasteValues);
                }
            }
        }
        public static async Task<int> CopyToConsumerPanelExcelAsync(Excel.Application app, List<ConsumerPanel> panelList, string dirName)
        {
            return await Task.Run<int>(
                () =>
                {
                    CopyToConsumerPanelExcel(app, panelList, dirName);
                    return 1;
                }
                );
        }
    }
}

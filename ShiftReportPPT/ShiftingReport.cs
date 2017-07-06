using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public class ShiftingReport
    {
        string filename;
        Excel.Application excelApp;
        Excel.Workbook dataWorkbook;
        List<ReportTable> reportTables;
        SortedSet<string> regions = new SortedSet<string>();

        public static ReportTable.RowFilter GetLessThanFilter(double thres)
        {
            return (string[] row) =>
            {
                Regex cn = new Regex("[\u4e00-\u9fa5]+");
                if (!cn.IsMatch(row[0]))
                {
                    //不替换纯英文的列
                    return row;
                }
                for (int i = 1; i < row.Length; i++)
                {
                    double res = 0;
                    if (!double.TryParse(row[i], out res) || Math.Abs(res) >= thres)
                    {
                        return row;
                    }
                }
                return null;
            };
        }

        public static ReportTable.RowFilter nameFilter = (string[] row) =>
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"光明健能AB100", "光明健能" }
            };
            string v;
            if (dict.TryGetValue(row[0], out v))
            {
                row[0] = v;
            }
            return row;
        };
        public SortedSet<string> Regions {
            get { ReadTables(); return regions; }
        }
        public ShiftingReport(string filename = "D:/粲然的程序/测试/原始表格.xlsx")
        {
            this.filename = filename;
        }

        public Task<List<ReportTable>> ReadTablesAsync()
        {
            return Task.Run<List<ReportTable>> (
                       () =>
                       {
                           this.ReadTables();
                           return reportTables;
                       }
                );
        }
        
        private List<ReportTable> ReadAllTableFromSheet(Excel.Worksheet sheet)
        {
            int col = sheet.UsedRange.Columns.Count;
            int totalRow = sheet.UsedRange.Rows.Count;
            //从第二列开始，便于发现表的第一行
            Excel.Range startCell = sheet.Cells[1, 2];
            startCell = startCell.End[Excel.XlDirection.xlDown];
            string value = startCell.Value;
            List<ReportTable> tables = new List<ReportTable>();
            while (value != null && value.Length != 0)
            {
                ReportTable table = new ReportTable();
                table.LoadDataArrayFromRange(sheet.Range[
                    startCell.Offset[0, -1], 
                    startCell.End[Excel.XlDirection.xlDown].End[Excel.XlDirection.xlToRight]
                    ]
                    );
                tables.Add(table);
                regions.Add(table.region);
                startCell =
                    startCell.End[Excel.XlDirection.xlDown].End[Excel.XlDirection.xlDown];
                value = startCell.Value;
            }
            return tables;
        }

        private List<ReportTable> ReadAllTableFromWorkbook(Excel.Workbook workbook)
        {
            List<ReportTable> l = new List<ReportTable>();
            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                l = l.Concat(ReadAllTableFromSheet(sheet)).ToList<ReportTable>();
            }
            return l;
        } 

        private void ReadTables()
        {
            if (reportTables == null)
            {
                reportTables = new List<ReportTable>();
                excelApp = new Excel.Application();
                dataWorkbook = excelApp.Workbooks.Open(filename, ReadOnly: true);
                reportTables = ReadAllTableFromWorkbook(dataWorkbook);
            }
        }

        public List<ReportTable> ReportTables
        {
            get
            {
                ReadTables();
                return reportTables;
            }
        }

        public List<ReportTable> GetRegionReportTables(string region)
        {
            ReadTables();
            List<ReportTable> l = new List<ReportTable>();
            foreach (ReportTable t in reportTables)
            {
                if (t.region == region)
                    l.Add(t);
            }
            return l;
        }

        public Task<List<ReportTable>> GetRegionReportTablesAsync(string region)
        {
            return Task.Run<List<ReportTable>>(
                () =>
                {
                    return GetRegionReportTables(region);
                }
                );
        }

        ~ShiftingReport()
        {
            if (dataWorkbook != null)
                dataWorkbook.Close(false);
            excelApp.Quit();
        }

        public Task<int> ExportExcelGroupByRegionAsync(string filename)
        {
            return Task.Run<int>(() =>
           {
               ExportExcelGroupByRegion(filename);
               return 1;
           });
        }
        public void ExportExcelGroupByRegion(string filename)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook book = app.Workbooks.Add();
            foreach (ReportTable table in reportTables)
            {
                Excel.Worksheet sheet = null;
                foreach (Excel.Worksheet s in book.Sheets)
                {
                    if (s.Name == table.region)
                    {
                        sheet = s;
                        break;
                    }
                }
                if (sheet == null)
                {
                    sheet = book.Sheets.Add();
                    sheet.Name = table.region;
                }
                table.ConvertToExcelRange(sheet.Cells[sheet.UsedRange.Rows.Count, 1]);
            }
            book.SaveAs(filename);
            book.Close(true);
            app.Quit();
        }
        
        public void RunFilter(ReportTable.RowFilter filter)
        {
            foreach (ReportTable table in reportTables)
            {
                table.FilterRows(filter);
            }
        }
    }
}

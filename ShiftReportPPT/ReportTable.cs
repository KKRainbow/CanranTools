using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;



namespace WindowsFormsApplication1
{
    public class ReportTable
    {
        public delegate string[] RowFilter(string[] row);
        public string vendor;
        public string region;
        public string description;
        //数据区的行数，列数（包括表头）
        public int row, col;
        public string[][] dataArray;
        public Excel.Range dataRange;
        public Dictionary<string, string> attrs = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="lefttop">左上角的单元格</param>
        /// <returns></returns>
        public Excel.Range ConvertToExcelRange(Excel.Range lefttop)
        {
            Excel.Worksheet sheet = lefttop.Worksheet;
            lefttop = lefttop.Offset[1, 0];
            lefttop.Value = "Gains/Losses = Volume Net Period 2";
            lefttop.Offset[1, 0].Value = "COMBxxxx = Ex-" + Tools.ProvinceHanziToPinyin(region);
            lefttop.Offset[2, 0].Value = "Shifting Report = " + vendor;

            Excel.Range range = sheet.Range[lefttop.Offset[3, 0], lefttop.Offset[3 + row, col]];
            for (int i = 0; i < dataArray.Length; i++)
            {
                for (int j = 0; j < dataArray[0].Length; j++)
                {
                    range.Cells[i + 1, j + 1].Value = dataArray[i][j];
                }
            }
            return lefttop.Offset[row + 3];
        }

        public void LoadDataArrayFromRange(Excel.Range dataRange)
        {
            Excel.Range startCell = dataRange.Cells[1, 1];

            string region = startCell.Offset[-2, 0].Value;
            string vendor = startCell.Offset[-1, 0].Value;
            string desc = startCell.Value;
            string[] splited = region.Split(new char[] { '-', '=' });
            this.region = Tools.ProvincePinyinToHanzi(splited[splited.Length - 1].Replace(" ", ""));
            this.vendor = vendor.Split(new char[] { '=' })[1].Replace(" ", "");
            description = desc;

            //一个表的最后一行
            Excel.Range endCell = startCell.End[Excel.XlDirection.xlDown];
            Excel.Range rightCell = startCell.End[Excel.XlDirection.xlToRight];
            row = endCell.Row - startCell.Row + 1;
            col = rightCell.Column - startCell.Column + 1;

            this.dataRange = dataRange;
            dataArray = new string[row][];
            var values = dataRange.Value;
            for (int i = 0; i < row; i++)
            {
                dataArray[i] = new string[col];
                for (int j = 0; j < col; j++)
                {
                    dataArray[i][j] = values[i + 1, j + 1].ToString().Replace(" ", "");
                }
            }
        }

        public ReportTable FilterRows(RowFilter filter)
        {
            List<string[]> data = new List<string[]>();
            bool flag = true;
            foreach (string[] row in dataArray)
            {
                if (flag)
                {
                    data.Add(row);
                    flag = false;
                    continue;
                }
                string[] newrow = filter(row);               
                if (newrow != null)
                {
                    data.Add(newrow);
                }
            }
            dataArray = new string[data.Count][];
            Array.Copy(data.ToArray(), dataArray, data.Count);
            row = data.Count;
            return this;
        }

    }
}

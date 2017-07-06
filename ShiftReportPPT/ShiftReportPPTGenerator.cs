using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ShiftReportPPTGenerator : Form
    {
        ReportToChart rtc;
        ShiftingReport sp;
        string outputPPTFilename = null;

        private async void PrepareData()
        {
            toolStripStatusLabel.Text = "读取Excel文件中，请稍候";
            try
            {
                await sp.ReadTablesAsync();
            }
            catch(Exception e)
            {
                toolStripStatusLabel.Text = "读取失败:" + e.ToString();
            }
            toolStripStatusLabel.Text = "读取成功";
        }

        public ShiftReportPPTGenerator()
        {
            InitializeComponent();
            rtc = new ReportToChart();
        }

        private void openDataExcelButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.CheckFileExists = true;
            fd.RestoreDirectory = true;
            fd.InitialDirectory = "d:/粲然的程序";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                sp = new ShiftingReport(fd.FileName);
                PrepareData();
            };
        }

        private void selectOutputPathButton_Click(object sender, EventArgs e)
        {
        }
        DataViewer dv;
        private void viewDataButton_Click(object sender, EventArgs e)
        {
            dv = new DataViewer();
            dv.Report = sp;
            dv.Show();
        }

        async void OutputPPT()
        {
            double limit = 0;
            if (!double.TryParse(filterThresholdTextBox.Text, out limit))
            {
                toolStripStatusLabel.Text = "请输入正确的数字";
                return;
            }
            SaveFileDialog fd = new SaveFileDialog();
            fd.InitialDirectory = "d:/";
            fd.Title = "请选择输出PPT的文件路径";
            fd.Filter = "PowerPoint files(*.pptx)|*.pptx;";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                outputPPTFilename = fd.FileName;
            }
            else
            {
                return;
            }
            toolStripStatusLabel.Text = "正在过滤数据";
            sp.RunFilter(ShiftingReport.GetLessThanFilter(limit));
            sp.RunFilter(ShiftingReport.nameFilter);
            toolStripStatusLabel.Text = "正在导出PPT";
            ReportToChart tc = new ReportToChart(outputPPTFilename);
            await tc.OutputAsync(sp, outputPPTFilename);
        }

        private void outputPPTButton_Click(object sender, EventArgs e)
        {
            OutputPPT();
        }

        async void OutputExcel()
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.InitialDirectory = "d:/";
            fd.Title = "请选择输出Excel的文件路径";
            fd.Filter = "PowerPoint files(*.xlsx)|*.xlsx;";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                double limit = 0;
                if (!double.TryParse(filterThresholdTextBox.Text, out limit))
                {
                    toolStripStatusLabel.Text = "请输入正确的数字";
                    return;
                }
                toolStripStatusLabel.Text = "正在过滤数据";               
                sp.RunFilter(ShiftingReport.GetLessThanFilter(limit));
                sp.RunFilter(ShiftingReport.nameFilter);
                toolStripStatusLabel.Text = "正在导出Excel";               
                await sp.ExportExcelGroupByRegionAsync("d:/test.xlsx");
                toolStripStatusLabel.Text = "导出成功";
            }
        }
        private void outputFilteredExcel_Click(object sender, EventArgs e)
        {
            OutputExcel();
        }
    }
}

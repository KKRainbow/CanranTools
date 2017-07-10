using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.KAOConsuperPanel;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    public partial class KAOConsumerPanel : Form
    {
        List<ConsumerPanel> consumerPanelList;
        List<SummaryPanel> summaryPanelList;
        string filePath;
        Excel.Application app;
        public KAOConsumerPanel()
        {
            InitializeComponent();
            app = new Excel.Application();
            app.Visible = true;
            OutputModelButton.Enabled = false;
            OutputSummaryButton.Enabled = false;
        }

        private async void SelectRowDataExcelButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.CheckFileExists = true;
            fd.RestoreDirectory = true;
            fd.InitialDirectory = "D:\\孙思杰\\桌面\\女王大人の任务\\花王\\新建文件夹";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                statusLabel.Text = "正在读取数据";
                string filename = fd.FileName;
                bool success = false;
                try
                {
                    consumerPanelList = await ConsumerPanel.ReadConsumerPanelsAsync(app, filename);
                    summaryPanelList = await SummaryPanel.ReadSummaryPanelsAsync(app, filename);
                    filePath = filename;
                    success = true;
                }
                catch (Exception exc)
                {
                    statusLabel.Text = "失败：" + exc.Message;
                    Trace.TraceError(exc.ToString());
                }
                if (success)
                {
                    statusLabel.Text = "读取成功";
                    OutputModelButton.Enabled = true;
                    OutputSummaryButton.Enabled = true;
                }
            };
        }

        ~KAOConsumerPanel()
        {
            foreach (Excel.Workbook book in app.Workbooks)
            {
                book.Close(false);
            }
            app.Quit();
        }

        private async void OutputModelButton_Click(object sender, EventArgs e)
        {
            string dirName = Path.Combine(Path.GetDirectoryName(filePath), "panel");
            bool suc = false;
            try
            {
                await ConsumerPanel.CopyToConsumerPanelExcelAsync(app, consumerPanelList, dirName);
                suc = true;
            }
            catch (Exception exc)
            {
                Trace.TraceError(exc.ToString());
                statusLabel.Text = "失败：" + exc.Message;
            }
            if (suc)
            {
                statusLabel.Text = "成功";
            }
        }

        private async void OutputSummaryButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.CheckFileExists = true;
            fd.RestoreDirectory = true;
            fd.InitialDirectory = "D:\\孙思杰\\桌面\\女王大人の任务\\花王\\新建文件夹";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                statusLabel.Text = "正在输出数据";
                bool success = false;
                try
                {
                    await SummaryPanel.CopyToSummaryPanelExcelAsync(app, summaryPanelList, fd.FileName);
                    success = true;
                }
                catch (Exception exc)
                {
                    Trace.TraceError(exc.ToString());
                    statusLabel.Text = "失败：" + exc.Message;
                }
                if (success)
                {
                    statusLabel.Text = "复制成功";
                }
            };
        }
    }
}

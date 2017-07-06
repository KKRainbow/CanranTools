using System;
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
    public partial class DataViewer : Form
    {
        private ShiftingReport report = null;

        public ShiftingReport Report
        {
            get { return report; }
            set { report = value; provinceDropdown.Items.AddRange(report.Regions.ToArray()); }
        }
        public DataViewer()
        {
            InitializeComponent();
        }
        private async void provinceDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            string region = box.Text;
            var r = await report.GetRegionReportTablesAsync(region);
            listView.Items.Clear();
            foreach (var t in r)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = t;
                item.Text = t.vendor;
                listView.Items.Add(item);
            }
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            ReportTable table = null;
            foreach (ListViewItem item in lv.SelectedItems)
            {
                table = item.Tag as ReportTable;
            }
            if (table == null)
            {
                return;
            }
            dataView.Columns.Clear();
            dataView.Rows.Clear();
            dataView.Visible = false;
            char ch = 'A';
            for (int i = 0; i < table.col; i++)
            {
                dataView.Columns.Add(i.ToString(), ch.ToString());
                dataView.Rows.Add(table.row);
                for (int j = 0; j < table.row; j++)
                    this.dataView[i, j].Value = table.dataArray[j][i];
                ch++;
            }
            dataView.Visible = true;
        }
    }
}

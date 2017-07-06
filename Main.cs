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
    public partial class Main : Form
    {

        KAOConsumerPanel kaoForm;
        ShiftReportPPTGenerator spForm;
        public Main()
        {
            InitializeComponent();
        }

        private void KAOConsumberPanelButton_Click(object sender, EventArgs e)
        {
            kaoForm = new KAOConsumerPanel();
            kaoForm.Show();
        }

        private void ShiftReportPPT_Click(object sender, EventArgs e)
        {
            spForm = new ShiftReportPPTGenerator();
            spForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSRC
{
    public partial class ExportListSI : Form
    {
        int dateFrom, dateTo;
        public ExportListSI()
        {
            InitializeComponent();
        }

        private void To_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTo = Convert.ToInt32(To_comboBox.Text);
        }
        private void From_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateFrom = Convert.ToInt32(From_comboBox.Text);
        }

        private void Export_button_Click(object sender, EventArgs e)
        {
            VerificationList verificationList = new VerificationList();
            verificationList.Start(dateFrom, dateTo);
        }
    }
}

using StaffSRC.Properties;
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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            ConnectionStr_TextBox.Text = Settings.Default["connectionString"].ToString();
            TableName_TextBox.Text = Settings.Default["tableName"].ToString();
        }

        // Сохранение настроек
        private void Save_button_Click(object sender, EventArgs e)
        {
            Staff_MainForm main = this.Owner as Staff_MainForm;

            Settings.Default["connectionString"] = (ConnectionStr_TextBox.Text).ToString();
            Settings.Default.Save();
            ConnectionStr_TextBox.Text = Settings.Default["connectionString"].ToString();

            Settings.Default["tableName"] = (TableName_TextBox.Text).ToString();
            Settings.Default.Save();
            TableName_TextBox.Text = Settings.Default["tableName"].ToString();

            main.DataGridView_Load();

            Close();
        }
    }
}

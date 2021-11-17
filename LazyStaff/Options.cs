using LazyStaff.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LazyStaff
{
    public partial class Options : Form
    {
        string admin_pass = Settings.Default["password"].ToString();

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
            main.connectionString = Settings.Default["connectionString"].ToString();                // Обновление переменной


            Settings.Default["tableName"] = (TableName_TextBox.Text).ToString();
            Settings.Default.Save();
            TableName_TextBox.Text = Settings.Default["tableName"].ToString();
            main.tableName = Settings.Default["tableName"].ToString();                              // Обновление переменной

            if (admin_pass == OldAdminPass_TextBox.Text)
            {
                Settings.Default["password"] = (NewAdminPass_TextBox.Text).ToString();
                Settings.Default.Save();
            }
            else
                MessageBox.Show("Неверный пароль");

            Thread dataGridUpdate = new Thread(main.DataGridView_Load);
            dataGridUpdate.Start();

            string message = "Настройки обновлены!";                                                       // Формировани текста окна
            string caption = "Успешно";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);                                            // Вывод диалогового окна
            if (result == System.Windows.Forms.DialogResult.OK)
                Close();
        }
    }
}

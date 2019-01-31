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
    public partial class PasswordInput : Form
    {
        public PasswordInput()
        {
            InitializeComponent();
        }



        static void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PasswordInput main = new PasswordInput();
                string password = main.password_TextBox.Text;
                main.Close();
            }
        }

        private void PasswordInput_Load(object sender, EventArgs e)
        {
            password_TextBox.KeyDown += new KeyEventHandler(tb_KeyDown);
        }
    }
}

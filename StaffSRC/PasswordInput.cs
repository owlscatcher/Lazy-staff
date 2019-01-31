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

        private void Enter()
        {
            password_TextBox.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        static void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
            }
        }
    }
}

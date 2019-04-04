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
    public partial class ReplaceDevice : Form
    {
        public ReplaceDevice()
        {
            InitializeComponent();
        }

        private void ReplaceDevice_Load(object sender, EventArgs e)
        {
            Staff_MainForm main = this.Owner as Staff_MainForm;

            dataGridView2.DataSource = main.dataTable;

            // настройка вида отображаемых колонок           
            dataGridView2.Columns[0].HeaderText = "Таб. №";
            dataGridView2.Columns[0].MinimumWidth = 30;

            dataGridView2.Columns[1].HeaderText = "Завод. №";
            dataGridView2.Columns[1].MinimumWidth = 30;

            dataGridView2.Columns[2].HeaderText = "Тип устройства";
            dataGridView2.Columns[2].MinimumWidth = 40;

            dataGridView2.Columns[3].HeaderText = "Год выпуска";
            dataGridView2.Columns[3].MinimumWidth = 40;

            dataGridView2.Columns[4].HeaderText = "Дата отправки";

            dataGridView2.Columns[5].HeaderText = "Дата ГП";

            dataGridView2.Columns[6].HeaderText = "Расположение";
            dataGridView2.Columns[6].MinimumWidth = 50;

            dataGridView2.Columns[7].HeaderText = "Продление";
            dataGridView2.Columns[7].MinimumWidth = 55;

            dataGridView2.Columns[8].HeaderText = "Тех. решение";
            dataGridView2.Columns[8].MinimumWidth = 60;

            dataGridView2.Columns[9].HeaderText = "ГАН";
            dataGridView2.Columns[9].MinimumWidth = 60;
            dataGridView2.Columns[9].Visible = false;

            dataGridView2.Columns[10].HeaderText = "Состояние";
            dataGridView2.Columns[10].MinimumWidth = 60;
            dataGridView2.Columns[10].Visible = false;
        }

        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            if (search_textBox.Text != "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)")
            {
                try
                {
                    dataGridView2.CurrentCell = null;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if ((dataGridView2.Rows[i].Cells[0].Value.ToString() == "" + search_textBox.Text) || (dataGridView2.Rows[i].Cells[1].Value.ToString() == "" + search_textBox.Text) || (dataGridView2.Rows[i].Cells[7].Value.ToString() == "" + search_textBox.Text))            // Фильтр по Табельному номеру
                            dataGridView2.Rows[i].Visible = true;
                        else
                            dataGridView2.Rows[i].Visible = false;

                        if (search_textBox.Text == "")
                        {
                            dataGridView2.Rows[i].Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
    }
}

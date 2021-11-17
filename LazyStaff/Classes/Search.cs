using System;
using System.Windows.Forms;

namespace LazyStaff.Classes
{
    class Search
    {
        public void Start(Form currentForm, DataGridView gridView, TextBox search_textBox)
        {
            ToolStripStatusLabel CountVisibleDevices_StatusLabel = null;
            if (currentForm is Staff_MainForm)
            {
                currentForm = (Staff_MainForm)currentForm;
                Staff_MainForm form = (Staff_MainForm)currentForm;
                CountVisibleDevices_StatusLabel = form.CountVisibleDevices_StatusLabel1;
            }
            if (currentForm is ReplaceDevice)
            {
                currentForm = (ReplaceDevice)currentForm;
                ReplaceDevice form = (ReplaceDevice)currentForm;
                CountVisibleDevices_StatusLabel = null;
            }


            if (search_textBox.Text != "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)")
            {
                try
                {
                    gridView.CurrentCell = null;
                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        if ((gridView.Rows[i].Cells[0].Value.ToString().Contains(search_textBox.Text)) 
                            || (gridView.Rows[i].Cells[1].Value.ToString().Contains(search_textBox.Text) 
                            || (gridView.Rows[i].Cells[6].Value.ToString().Contains(search_textBox.Text) 
                            || (gridView.Rows[i].Cells[7].Value.ToString().Contains(search_textBox.Text)))))            // Фильтр по Табельному номеру
                            gridView.Rows[i].Visible = true;
                        else
                            gridView.Rows[i].Visible = false;

                        if (search_textBox.Text == "")
                        {
                            gridView.Rows[i].Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            if (CountVisibleDevices_StatusLabel != null)
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + gridView.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
        }
    }
}

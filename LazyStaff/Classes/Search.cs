using System;
using System.Windows.Forms;
using LazyStaff.Models;

namespace LazyStaff.Classes
{
    class Search
    {
        public void Start(Form currentForm, DataGridView gridView, TextBox search_textBox)
        {
            ToolStripStatusLabel countLabel = null;
            if (currentForm is Staff_MainForm mainForm)
                countLabel = mainForm.CountVisibleDevices_StatusLabel1;

            string text = search_textBox.Text ?? "";
            if (text == "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)")
                text = "";

            try
            {
                gridView.CurrentCell = null;
                string search = text.Trim();
                for (int i = 0; i < gridView.Rows.Count; i++)
                {
                    var device = gridView.Rows[i].DataBoundItem as Device;
                    if (device == null)
                    {
                        gridView.Rows[i].Visible = true;
                        continue;
                    }
                    if (string.IsNullOrEmpty(search))
                    {
                        gridView.Rows[i].Visible = true;
                        continue;
                    }
                    bool match = (device.PassportId.ToString().Contains(search)) || 
                                (device.Id.ToString().Contains(search)) ||
                                (device.SerialId.ToString().Contains(search)) ||
                                (device.Loaction != null && device.Loaction.Contains(search)) ||
                                (device.ValidTo != default && device.ValidTo.Contains(search));
                    gridView.Rows[i].Visible = match;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            if (countLabel != null)
                countLabel.Text = "Отображено приборов: " + gridView.Rows.GetRowCount(DataGridViewElementStates.Visible);
        }
    }
}

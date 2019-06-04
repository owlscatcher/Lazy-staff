using System;
using System.Windows.Forms;

namespace StaffSRC.Classes
{
    class TreeViewFilter
    {
        public void Filter(Staff_MainForm staff_MainForm, int level, int index)
        {
            if (level != 0)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (!staff_MainForm.dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(staff_MainForm.TreeView.SelectedNode.Text.ToString()))
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //--------------------------------------------------------------------------------

            //***************************
            // Фильтры по типу устройств
            //***************************
            if (staff_MainForm.TreeView.Nodes[0].IsSelected)                                                             // Фильтр для всех
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    staff_MainForm.dataGridView1.Rows[i].Visible = true;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //**********************************
            // Фильтр консервировнных устройств
            //**********************************

            // значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация

            if (staff_MainForm.TreeView.Nodes[3].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 4)                 // где 1 - отправлен, 0 - нет
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр готовящихся устройств
            //********************************
            if (staff_MainForm.TreeView.Nodes[1].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 5 || Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 7)                // где 5 - Прибор готовится на отправку
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр отправленных устройств
            //********************************
            if (staff_MainForm.TreeView.Nodes[4].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 2)                // где 1 - отправлен, 0 - нет
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр просроченных устройств
            //********************************
            if (staff_MainForm.TreeView.Nodes[2].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 1 || Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 6)                // где 1 - отправлен, 0 - нет
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр устройств на складе
            //********************************
            if (staff_MainForm.TreeView.Nodes[5].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 3 || Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 6 || Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 7)                // где 1 - отправлен, 0 - нет
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр устройств ГАН
            //********************************
            if (staff_MainForm.TreeView.Nodes[6].Nodes[0].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(staff_MainForm.dataGridView1.Rows[i].Cells[9].Value) == true)                       // где true - ГАН, false - не ГАН
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }
            //********************************
            // Фильтр устройств не ГАН
            //********************************
            if (staff_MainForm.TreeView.Nodes[6].Nodes[1].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(staff_MainForm.dataGridView1.Rows[i].Cells[9].Value) == false)                       // где true - ГАН, false - не ГАН
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр списанных устройств
            //********************************
            if (staff_MainForm.TreeView.Nodes[6].Nodes[2].IsSelected)
            {
                staff_MainForm.dataGridView1.CurrentCell = null;
                for (int i = 0; i < staff_MainForm.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(staff_MainForm.dataGridView1.Rows[i].Cells[10].Value) == 8)                            // где 8 - списан
                        staff_MainForm.dataGridView1.Rows[i].Visible = true;
                    else
                        staff_MainForm.dataGridView1.Rows[i].Visible = false;
                }
                staff_MainForm.CountVisibleDevices_StatusLabel1.Text = ("Отображено приборов: " + staff_MainForm.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }
        }
    }
}

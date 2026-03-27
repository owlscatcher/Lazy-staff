using System;
using System.Windows.Forms;
using LazyStaff.Models;

namespace LazyStaff.Classes
{
    class TreeViewFilter
    {
        private const int TreeIndexAll = 0;
        private const int TreeIndexPreparing = 1;
        private const int TreeIndexOverdue = 2;
        private const int TreeIndexCanned = 3;
        private const int TreeIndexSent = 4;
        private const int TreeIndexStorage = 5;
        private const int TreeIndexSpecial = 6;
        private const int TreeIndexGan = 0;
        private const int TreeIndexNotGan = 1;
        private const int TreeIndexDecommissioned = 2;

        private const int RootLevel = 0;

        public void Filter(Staff_MainForm staff_MainForm, int level, int index)
        {
            DataGridView grid = staff_MainForm.dataGridView1;
            TreeNodeCollection rootNodes = staff_MainForm.TreeView.Nodes;

            if (level != RootLevel)
            {
                string selectedType = staff_MainForm.TreeView.SelectedNode?.Text ?? "";
                ApplyFilter(staff_MainForm, grid, row =>
                {
                    return row.DataBoundItem is Device device && device.DeviceTypeName.ToString().Contains(selectedType);
                });
                return;
            }

            if (rootNodes[TreeIndexAll].IsSelected)
            {
                ApplyFilter(staff_MainForm, grid, _ => true);
                return;
            }

            if (rootNodes[TreeIndexCanned].IsSelected)
            {
                ApplyFilterByStatus(staff_MainForm, grid, (int)Status.Canned);
                return;
            }

            if (rootNodes[TreeIndexPreparing].IsSelected)
            {
                ApplyFilterByStatus(staff_MainForm, grid, (int)Status.PreparingForSend, (int)Status.PreparingForSendAndInStock);
                return;
            }

            if (rootNodes[TreeIndexSent].IsSelected)
            {
                ApplyFilterByStatus(staff_MainForm, grid, (int)Status.Sended);
                return;
            }

            if (rootNodes[TreeIndexOverdue].IsSelected)
            {
                ApplyFilterByStatus(staff_MainForm, grid, (int)Status.Overdue, (int)Status.OverdueAndInStock);
                return;
            }

            if (rootNodes[TreeIndexStorage].IsSelected)
            {
                ApplyFilterByStatus(staff_MainForm, grid, (int)Status.InStock, (int)Status.OverdueAndInStock, (int)Status.PreparingForSendAndInStock);
                return;
            }

            TreeNodeCollection specialNodes = rootNodes[TreeIndexSpecial].Nodes;
            if (specialNodes[TreeIndexGan].IsSelected)
            {
                ApplyFilterByGan(staff_MainForm, grid, isGan: true);
                return;
            }

            if (specialNodes[TreeIndexNotGan].IsSelected)
            {
                ApplyFilterByGan(staff_MainForm, grid, isGan: false);
                return;
            }

            if (specialNodes[TreeIndexDecommissioned].IsSelected)
            {
                ApplyFilterByStatus(staff_MainForm, grid, (int)Status.WrittenOff);
            }
        }

        private static void ApplyFilter(Staff_MainForm form, DataGridView grid, Func<DataGridViewRow, bool> isVisible)
        {
            grid.CurrentCell = null;
            for (int i = 0; i < grid.Rows.Count; i++)
                grid.Rows[i].Visible = isVisible(grid.Rows[i]);
            UpdateVisibleCount(form, grid);
        }

        private static void ApplyFilterByStatus(Staff_MainForm form, DataGridView grid, params int[] allowedStatuses)
        {
            ApplyFilter(form, grid, row =>
            {
                var device = row.DataBoundItem as Device;
                if (device == null) return false;
                foreach (int s in allowedStatuses)
                    if (device.Status == s) return true;
                return false;
            });
        }

        private static void ApplyFilterByGan(Staff_MainForm form, DataGridView grid, bool isGan)
        {
            ApplyFilter(form, grid, row =>
            {
                var device = row.DataBoundItem as Device;
                return device != null && device.IsGun == isGan;
            });
        }

        private static void UpdateVisibleCount(Staff_MainForm form, DataGridView grid)
        {
            form.CountVisibleDevices_StatusLabel1.Text = "Отображено приборов: " + grid.Rows.GetRowCount(DataGridViewElementStates.Visible);
        }
    }
}

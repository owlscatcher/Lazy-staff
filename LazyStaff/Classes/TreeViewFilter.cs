using System;
using System.Windows.Forms;
using LazyStaff.Models;

namespace LazyStaff.Classes
{
    /// <summary>
    /// Фильтрация грида по выбранному узлу TreeView (имя типа прибора, статус, особые списки).
    /// Узел «Все приборы» (Name = All) и служебные узлы — в Designer; типы приборов под All заполняются при загрузке данных.
    /// </summary>
    class TreeViewFilter
    {
        /// <summary>Родительский узел «Все приборы» — дочерние узлы это типы (УИМ, БДАС, …).</summary>
        private const string NodeAllDevices = "All";

        private const string NodePreparing = "PREPROSROCH";
        private const string NodeOverdue = "PROSROCH";
        private const string NodeCanned = "KONSERV";
        private const string NodeSent = "OTPRAVLENNIE";
        private const string NodeStorage = "SKLAD";
        private const string NodeSpecialLists = "lists";
        private const string NodeGan = "gan";
        private const string NodeNotGan = "notgan";
        private const string NodeDecommissioned = "decommissioned";

        public void Filter(Staff_MainForm staff_MainForm)
        {
            DataGridView grid = staff_MainForm.dataGridView1;
            TreeNode node = staff_MainForm.TreeView.SelectedNode;
            if (node == null) return;

            // Тип прибора: дочерние узлы под «Все приборы» (уровень 1, родитель Name = All)
            if (node.Level == 1 && node.Parent != null && string.Equals(node.Parent.Name, NodeAllDevices, StringComparison.Ordinal))
            {
                ApplyFilterByDeviceTypeName(staff_MainForm, grid, node);
                return;
            }

            switch (node.Name)
            {
                case NodeAllDevices:
                    ApplyFilter(staff_MainForm, grid, _ => true);
                    break;

                case NodePreparing:
                    ApplyFilterByStatus(staff_MainForm, grid, (int)Status.PreparingForSend, (int)Status.PreparingForSendAndInStock);
                    break;

                case NodeOverdue:
                    ApplyFilterByStatus(staff_MainForm, grid, (int)Status.Overdue, (int)Status.OverdueAndInStock);
                    break;

                case NodeCanned:
                    ApplyFilterByStatus(staff_MainForm, grid, (int)Status.Canned);
                    break;

                case NodeSent:
                    ApplyFilterByStatus(staff_MainForm, grid, (int)Status.Sended);
                    break;

                case NodeStorage:
                    ApplyFilterByStatus(staff_MainForm, grid, (int)Status.InStock, (int)Status.OverdueAndInStock, (int)Status.PreparingForSendAndInStock);
                    break;

                case NodeSpecialLists:
                    // Клик по родителю «Особые списки» без выбора дочернего — показываем весь список
                    ApplyFilter(staff_MainForm, grid, _ => true);
                    break;

                case NodeGan:
                    ApplyFilterByGan(staff_MainForm, grid, isGan: true);
                    break;

                case NodeNotGan:
                    ApplyFilterByGan(staff_MainForm, grid, isGan: false);
                    break;

                case NodeDecommissioned:
                    ApplyFilterByStatus(staff_MainForm, grid, (int)Status.WrittenOff);
                    break;

                default:
                    ApplyFilter(staff_MainForm, grid, _ => true);
                    break;
            }
        }

        private static void ApplyFilterByDeviceTypeName(Staff_MainForm form, DataGridView grid, TreeNode typeNode)
        {
            string typeText = typeNode.Text?.Trim() ?? "";
            string typeCode = typeNode.Name?.Trim() ?? "";

            ApplyFilter(form, grid, row =>
            {
                var device = row.DataBoundItem as Device;
                if (device == null) return false;

                string dt = device.DeviceTypeName?.Trim();
                if (string.IsNullOrEmpty(dt)) return false;

                if (typeText.Length > 0 && dt.IndexOf(typeText, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
                if (typeCode.Length > 0 && dt.IndexOf(typeCode, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;

                return false;
            });
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

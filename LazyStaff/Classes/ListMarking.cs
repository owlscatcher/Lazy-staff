using System;
using System.Drawing;
using System.Windows.Forms;
using LazyStaff.Models;

namespace LazyStaff.Classes
{
    class ListMarking
    {
        /// <summary>Минимальное число дней с поверки, чтобы подсветить "готовится к отправке" (за 30 дней до года).</summary>
        private const int DaysBeforeExpiryToPrepareMin = 30;

        private const string ColorWhite = "#FFFFFF";
        private const string ColorOverdue = "#B40404";
        private const string ColorSent = "#58ACFA";
        private const string ColorStorage = "#58FA82";
        private const string ColorConservation = "#F6CED8";
        private const string ColorPreparingForSend = "#F3F781";
        private const string ColorDecommissioned = "#6E6E6E";

        public void Start(Staff_MainForm staff_MainForm)
        {
            DataGridView dataGridView1 = staff_MainForm.dataGridView1;
            Label conservation_label = staff_MainForm.Conservation_label;
            Label sent_label = staff_MainForm.Sent_label;
            Label overdue_label = staff_MainForm.Overdue_label;
            Label storage_label = staff_MainForm.Storage_label;
            Label decommissioned_label = staff_MainForm.Decommissioned_label;
            Label allDevides_label = staff_MainForm.AllDevides_label;
            Label gan_label = staff_MainForm.Gan_label;
            Label notgan_label = staff_MainForm.Notgan_label;
            ToolStripStatusLabel CountVisibleDevices_StatusLabel = staff_MainForm.CountVisibleDevices_StatusLabel1;

            DateTime currentDate = DateTime.Now.Date;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var device = dataGridView1.Rows[i].DataBoundItem as Device;
                if (device == null) continue;

                bool isExcludedFromExpiryCheck = device.Status == (int)Status.Sended || device.Status == (int)Status.Canned || device.Status == (int)Status.WrittenOff;
                if (isExcludedFromExpiryCheck || device.DateCheck == default)
                    continue;

                var monthLength = 30;
                var nextMcDate = device.DateCheck.AddDays((device.MetrologicalControlInterval * monthLength) + 5);
                int days = (int)nextMcDate.Subtract(currentDate).TotalDays;
                
                if (days <= DaysBeforeExpiryToPrepareMin)
                {
                    bool isOnStorage = device.Status == (int)Status.InStock || device.Status == (int)Status.PreparingForSendAndInStock;
                    device.Status = isOnStorage ? (int)Status.PreparingForSendAndInStock : (int)Status.PreparingForSend;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorPreparingForSend);
                }
                else if (days <= 0)
                {
                    bool isOnStorage = device.Status == (int)Status.InStock || device.Status == (int)Status.OverdueAndInStock;
                    device.Status = isOnStorage ? (int)Status.OverdueAndInStock : (int)Status.Overdue;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorOverdue);
                }
            }

            int conservation = 0, sent = 0, overdue = 0, storage = 0, allDevices = 0, gan = 0, notgan = 0, decommissioned = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var device = dataGridView1.Rows[i].DataBoundItem as Device;
                if (device == null) continue;

                allDevices++;

                switch ((Status)device.Status)
                {
                    case Status.Normal:
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorWhite);
                        break;
                    case Status.Overdue:
                        overdue++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorOverdue);
                        break;
                    case Status.Sended:
                        sent++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorSent);
                        break;
                    case Status.InStock:
                        storage++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorStorage);
                        break;
                    case Status.Canned:
                        conservation++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorConservation);
                        break;
                    case Status.PreparingForSend:
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorPreparingForSend);
                        break;
                    case Status.OverdueAndInStock:
                        overdue++;
                        storage++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorOverdue);
                        break;
                    case Status.PreparingForSendAndInStock:
                        storage++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorPreparingForSend);
                        break;
                    case Status.WrittenOff:
                        decommissioned++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorDecommissioned);
                        break;
                    default:
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(ColorWhite);
                        break;
                }

                if (device.IsGun)
                    gan++;
                else
                    notgan++;
            }
            staff_MainForm.Invoke((MethodInvoker)delegate
            {
                conservation_label.Text = ("На консервации: " + conservation.ToString());
                sent_label.Text = ("Отправлено: " + sent.ToString());
                overdue_label.Text = ("Просрочено: " + overdue.ToString());
                storage_label.Text = ("На складе: " + storage.ToString());
                decommissioned_label.Text = ("Списанных: " + decommissioned.ToString());
                allDevides_label.Text = ("Всего устройств: " + (allDevices - decommissioned).ToString() + " (" + allDevices + ")");
                gan_label.Text = ("Приборов ГАН: " + gan.ToString());
                notgan_label.Text = ("Приборов не ГАН: " + notgan.ToString());

                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            });
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LazyStaff.Classes
{
    class ListMarking
    {
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

            //---------------------------------------
            // Проверка просрочки
            //---------------------------------------

            // значения stage: 0 - норма (установлен, поверен), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервации, 5 - готовится к отправке
            //                 6 - просрочен и на складе, 7 - готовится к отправке и на складе, 8 - списан

            // dataGridView1.Rows[i].Cells[10].Value - stage (состояние прибора)
            // dataGridView1.Rows[i].Cells[5].Value  - дата гос.поверки

            DateTime currentDate, verificationDate = new DateTime();
            currentDate = DateTime.Now.Date;                                                                                        // актуальная дата
            verificationDate = verificationDate.Date;                                                                               // дата из базы данных прибора

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) != 2 &&
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) != 4 &&
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) != 8 &&
                    dataGridView1.Rows[i].Cells[5].Value != DBNull.Value)                                                           // Если прибор не на консервации, не списан и не отправлен
                {
                    verificationDate = (Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value));
                    int days = (int)currentDate.Subtract(verificationDate).TotalDays;                                               // получаем разность между currentDate и verificationDate в днях

                    if (days >= 335 && days <= 365)                                                                                 // подготовить на отправку || для продления
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) != 3 && Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) != 7)
                        {
                            dataGridView1.Rows[i].Cells[10].Value = 5;
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3F781");
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[10].Value = 7;
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3F781");
                        }
                    }
                    if (days >= 366)                                                                                                // просроченный прибор
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) != 3 && Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) != 6)
                        {
                            dataGridView1.Rows[i].Cells[10].Value = 1;
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B40404");
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[10].Value = 6;
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B40404");
                        }
                    }
                    else
                        continue;
                }
                else
                    continue;
            }

            //---------------------------------------
            // Маркировка списка
            //---------------------------------------
            int conservation = 0, sent = 0, overdue = 0, storage = 0, allDevices = 0, gan = 0, notgan = 0, decommissioned = 0;      // счетчики

            for (int i = 0; i < dataGridView1.Rows.Count; i++)                                                                      // цикл маркировки
            {
                allDevices++;
                // значения stage хранятся в ячейках [10] || .Cells[10].Value
                // значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация
                //                 5 - готовится на отправку, 6 - просрочен и на складе, 7 - готовится на отправку и на складе, 8 - списан
                switch (dataGridView1.Rows[i].Cells[10].Value)
                {
                    case 0:
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        break;
                    case 1: // просрочен
                        overdue++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B40404");
                        break;
                    case 2: // отправлен
                        sent++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#58ACFA");
                        break;
                    case 3: // на складе
                        storage++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#58FA82");
                        break;
                    case 4: // консервирован
                        conservation++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F6CED8");
                        break;
                    case 5: // на отправку
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3F781");
                        break;
                    case 6: // просрочен и на складе
                        overdue++;
                        storage++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B40404");
                        break;
                    case 7: // на отправку и на складе
                        storage++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3F781");
                        break;
                    case 8: // списан
                        decommissioned++;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#6E6E6E");
                        break;
                    default:
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        break;
                }

                //значения stageGan: false - не в списке ГАН, true - в списке ГАН (маркеруется в default)

                switch (dataGridView1.Rows[i].Cells[9].Value)
                {
                    case false:
                        ++notgan;
                        break;
                    default:
                        ++gan;
                        break;
                }
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

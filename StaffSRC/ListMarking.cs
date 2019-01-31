using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSRC
{
    class ListMarking
    {
        public int[] Start()
        {
            Staff_MainForm mainForm = new Staff_MainForm();

            //---------------------------------------
            // Проверка просрочки
            //---------------------------------------

            // значения stage: 0 - норма (установлен, поверен), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация

            DateTime currentDate, verificationDate = new DateTime();
            currentDate = DateTime.Now.Date;                                                                                        // актуальная дата
            verificationDate = verificationDate.Date;                                                                               // дата из базы данных прибора

            for (int i = 0; i < mainForm.dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(mainForm.dataGridView1.Rows[i].Cells[9].Value) != 1 && Convert.ToInt32(mainForm.dataGridView1.Rows[i].Cells[10].Value) != 1 && mainForm.dataGridView1.Rows[i].Cells[5].Value != DBNull.Value)  // Если прибор не на консервации и не отправлен
                {
                    verificationDate = (Convert.ToDateTime(mainForm.dataGridView1.Rows[i].Cells[5].Value));
                    int days = (int)currentDate.Subtract(verificationDate).TotalDays;                                               // получаем разность между currentDate и verificationDate в днях

                    if (days >= 335 && days <= 365)                                                                                 // подготовить на отправку || для продления
                    {
                        mainForm.dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3F781");
                    }
                    if (days >= 366)                                                                                                // просроченный прибор
                    {
                        mainForm.dataGridView1.Rows[i].Cells[9].Value = 1;
                        mainForm.dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B40404");
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
            int conservation = 0, sent = 0, overdue = 0, storage = 0, allDevices = 0, gan = 0, notgan = 0;                           // счетчики

            for (int i = 0; i < mainForm.dataGridView1.Rows.Count; i++)                                                             // цикл маркировки
            {
                allDevices++;
                // значения stage хранятся в ячейках [9] || .Cells[9].Value
                // значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация
                switch (mainForm.dataGridView1.Rows[i].Cells[9].Value)
                {
                    case 0:
                        break;
                    case 1:
                        overdue++;
                        mainForm.dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B40404");
                        break;
                    case 2:
                        sent++;
                        mainForm.dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#58ACFA");
                        break;
                    case 3:
                        storage++;
                        mainForm.dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#58FA82");
                        break;
                    case 4:
                        conservation++;
                        mainForm.dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F6CED8");
                        break;
                    default:
                        mainForm.dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        break;
                }

                //значения stageGan: false - не в списке ГАН, true - в списке ГАН (маркеруется в default)

                switch (mainForm.dataGridView1.Rows[i].Cells[10].Value)
                {
                    case false:
                        ++notgan;
                        break;
                    default:
                        ++gan;
                        break;
                }
            }
            int[] Stage = new int[7] { overdue, sent, storage, conservation, gan, notgan, allDevices };
            return Stage;
        }
    }
}

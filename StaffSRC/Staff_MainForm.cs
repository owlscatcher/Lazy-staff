using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ExcelDLL = Microsoft.Office.Interop.Excel;
using System.Security.Principal;
using StaffSRC.Properties;

using Spire.Pdf;

namespace StaffSRC
{
    public partial class Staff_MainForm : Form
    {
        public DataSet dataSet = new DataSet();
        public DataTable dataTable = new DataTable();
        public string password, querry, connectionString, tableName, personnelNumber, 
            factoryNumber, deviceType, yearOfIssue, deviceLocation, verifiedTo, 
            solutionNumber, sentDate, verificationDate, help_serachTB = "Введите Табульный/Заводской номер или дату продления";
        public int index, state;
        public bool gan_state;
        public static bool administration;

        //-----------------------------------
        // Кнопка экспорта из DGV в Excel
        //-----------------------------------
        private void ExportToXml_button_Click(object sender, EventArgs e)
        {
            Thread exportToExcel = new Thread(ExportToExcel);
            exportToExcel.Start();
        }

        //-----------------------------------
        // Кнопка вызова справки по УИМ2-2
        //-----------------------------------
        private void uimInfo_button_Click(object sender, EventArgs e)
        {
            Uim_info uimInfo = new Uim_info();
            uimInfo.Show();
        }

        //-----------------------------------
        // кнопка ПЕЧАТЬ
        //-----------------------------------
        private void PrintPdf_button_Click(object sender, EventArgs e)
        {
            PDF();
        }

        //-----------------------------------
        // кнопка НАСТРОЙКИ
        //-----------------------------------
        private void Setting_button_Click(object sender, EventArgs e)
        {
            Options Option = new Options();                                                             // Открыть окно настроек
            Option.Owner = this;
            Option.Show();
        }

        //-----------------------------------
        // Изменение положения toggle
        //-----------------------------------
        void ToggleSwitch_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ToggleSwitch1.Toggled == true)
            {
                PasswordInput passwordInput = new PasswordInput();

                passwordInput.StartPosition = FormStartPosition.Manual;

                int x = Cursor.Position.X;
                int y = Cursor.Position.Y - 20;

                passwordInput.Location = new Point(Cursor.Position.X, y);

                passwordInput.ShowDialog();

                if (administration==true)
                {
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                }
                else
                {
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    administration = false;
                }
            }
            else
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                administration = false;
            }

        }

        //-----------------------------------
        // Инициализация
        //-----------------------------------
        public Staff_MainForm()
        {
            InitializeComponent();

            // Включаем двойную буферизацию для DataGridView
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null,
                dataGridView1,
                new object[] { true });

            test_radioButton.Checked = true;
            progressBar1.Visible = false;

            // загрузка настроек 
            connectionString = Settings.Default["connectionString"].ToString();
            tableName = Settings.Default["tableName"].ToString();
            password = Settings.Default["password"].ToString();

            ToggleSwitch1.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(ToggleSwitch_MouseLeftButtonDown);
            administration = false;

            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            
        }

        //-----------------------------------
        // Событие изменение select состояния строки
        //-----------------------------------
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string selectedRowsCount = dataGridView1.SelectedRows.Count.ToString();
            CountStatusLabel_StatusPanel.Text = "Количество выделенных приборов: " + selectedRowsCount;
        }

        //-----------------------------------
        // Событие окончания сортировки, обновление маркеровки
        //-----------------------------------
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            ListMarking();
        }

        //---------------------------------
        // Замена устройства
        //---------------------------------
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Отрабатывает клик по кнопке
            if (administration == true)
            {
                // обнуляем глобальные переменные, что бы избежать заполнение строк неверной информацией
                personnelNumber = null; factoryNumber = null; deviceType = null; yearOfIssue = null; sentDate = null; verificationDate = null; deviceLocation = null; verifiedTo = null; solutionNumber = null;

                personnelNumber = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                factoryNumber = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                deviceType = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                yearOfIssue = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);

                if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) != "")
                {
                    sentDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value).ToShortDateString();
                }
                if (Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value) != "")
                {
                    verificationDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value).ToShortDateString();
                }

                deviceLocation = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                verifiedTo = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
                solutionNumber = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
                state = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);
                gan_state = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[9].Value);

                ReplaceDevice ReplaceDevice = new ReplaceDevice();
                ReplaceDevice.Owner = this;
                ReplaceDevice.Show();
            }
            else
                MessageBox.Show("Недостаточно прав для редактирования, обратитесь к администратору");
            return;
        }
        //-----------------------------------
        // Изменение устройства
        //-----------------------------------
        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (administration == true)
            {
                // обнуляем глобальные переменные, что бы избежать заполнение строк неверной информацией
                personnelNumber = null; factoryNumber = null; deviceType = null; yearOfIssue = null; sentDate = null; verificationDate = null; deviceLocation = null; verifiedTo = null; solutionNumber = null;

                personnelNumber = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                factoryNumber = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                deviceType = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                yearOfIssue = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);

                if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) != "")
                {
                    sentDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value).ToShortDateString();
                }
                if (Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value) != "")
                {
                    verificationDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value).ToShortDateString();
                }

                deviceLocation = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                if (dataGridView1.CurrentRow.Cells[7].Value != DBNull.Value)
                    verifiedTo = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
                else
                    verifiedTo = null;
                solutionNumber = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
                state = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);
                gan_state = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[9].Value);

                Change_device ChangeDev = new Change_device();
                ChangeDev.Owner = this;
                ChangeDev.Show();
            }
            else
                MessageBox.Show("Недостаточно прав для редактирования, обратитесь к администратору");
            return;
        }

        //------------------------------------
        // Выделение Row по ПКМ
        //------------------------------------
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
            }
        }

        //-----------------------------------
        // Удаление устройства
        //-----------------------------------
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (administration == true)
            {
                string id = (dataGridView1.Rows[index].Cells[0].Value).ToString();

                string message = "Удалить устройство с табульным №" + id + " из базы данных";                                       // Формировани текста окна ошибки
                string caption = "Подтверждение:";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);                                                            // Вывод диалогового окна
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    querry = "DELETE FROM " + tableName + " WHERE personnelNumber=" + id;

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(querry, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();

                    DataGridView_Load();

                    dataGridView1.Refresh();

                    MessageBox.Show("Устройство удалёно!");
                }
            }
            else
                MessageBox.Show("Недостаточно прав для редактирования, обратитесь к администратору");
            return;
        }

        //-----------------------------------
        // Событие при первом отображении формы, загрузка из бд
        //-----------------------------------
        private void Staff_MainForm_Shown(object sender, EventArgs e)
        {
            // Заполняем таблицу из MS SQL
            Thread dataGridUpdate = new Thread(DataGridView_Load);
            dataGridUpdate.Start();
        }


        //----------------------------------------------------------------------------
        // Загрузка данных из DataGridView
        //----------------------------------------------------------------------------
        public void DataGridView_Load()
        {
            dataSet.Clear();                                                                                    // Очистили DataSet

            SqlConnection connection = new SqlConnection(connectionString);
            string querry = ("SELECT * FROM " + tableName + "");                                                // запрос к sql db на получение строк
            SqlDataAdapter dataAdapter = new SqlDataAdapter(querry, connection);                                // создаем экземпляр dataAdapter для получения строк из sql db

            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                string message = "Не удалось подклюиться к базе данных. Открыть настройки?";                  // Формировани текста окна ошибки
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;                                            // Формирование кнопок Да/Нет
                DialogResult result;                                                                            // В какую переменную вывести 
                result = MessageBox.Show(message, caption, buttons);                                            // Вывод диалогового окна
                if (result == System.Windows.Forms.DialogResult.Yes)                                            // Если нажмем кнопку Да
                {
                    Options Option = new Options();                                                             // Открыть окно настроек
                    Option.Owner = this;
                    Invoke((MethodInvoker)delegate
                    {
                        Option.Show();
                    });
                    return;
                }
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    Application.Exit();
                    return;
                }

            }

            dataAdapter.Fill(dataSet, "Monitor");                                                               // помещаем строки в dataSet, называем таблицу Monitor
            dataTable = dataSet.Tables["Monitor"].Copy();                                                       
            connection.Close();                                                                                 // закрываем соединение

            Invoke((MethodInvoker)delegate
            {
                dataGridView1.DataSource = dataTable;                                                               // заводим источик данный
                                                                                                                    //dataGridView1.DataMember = "Monitor";                                                             // создаем DataMemder

                // настройка вида отображаемых колонок           
                dataGridView1.Columns[0].HeaderText = "Таб. №";
                dataGridView1.Columns[0].MinimumWidth = 30;

                dataGridView1.Columns[1].HeaderText = "Завод. №";
                dataGridView1.Columns[1].MinimumWidth = 30;

                dataGridView1.Columns[2].HeaderText = "Тип устройства";
                dataGridView1.Columns[2].MinimumWidth = 40;

                dataGridView1.Columns[3].HeaderText = "Год выпуска";
                dataGridView1.Columns[3].MinimumWidth = 40;

                dataGridView1.Columns[4].HeaderText = "Дата отправки";

                dataGridView1.Columns[5].HeaderText = "Дата ГП";

                dataGridView1.Columns[6].HeaderText = "Расположение";
                dataGridView1.Columns[6].MinimumWidth = 50;

                dataGridView1.Columns[7].HeaderText = "Продление";
                dataGridView1.Columns[7].MinimumWidth = 55;

                dataGridView1.Columns[8].HeaderText = "Тех. решение";
                dataGridView1.Columns[8].MinimumWidth = 60;

                dataGridView1.Columns[9].HeaderText = "ГАН";
                dataGridView1.Columns[9].MinimumWidth = 60;
                dataGridView1.Columns[9].Visible = false;

                dataGridView1.Columns[10].HeaderText = "Состояние";
                dataGridView1.Columns[10].MinimumWidth = 60;
                dataGridView1.Columns[10].Visible = false;
            });

            ListMarking();

            DateTime dateTime = DateTime.Now;
            SyncStatusLabel_StatusPanel.Text = "Последняя синхронизация: " + dateTime.ToString();
        }
        //-----------------------------------------------------
        // Маркировка списка и проверка просроченных приборов
        //-----------------------------------------------------
        public void ListMarking()
        {
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
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = DefaultBackColor;
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

            Invoke((MethodInvoker)delegate
            {
                conservation_label.Text = ("На консервации: " + conservation.ToString());
                sent_label.Text = ("Отправлено: " + sent.ToString());
                overdue_label.Text = ("Просрочено: " + overdue.ToString());
                storage_label.Text = ("На складе: " + storage.ToString());
                decommissioned_label.Text = ("Списанных: " + decommissioned.ToString());
                allDevides_label.Text = ("Всего устройств: " + (allDevices-decommissioned).ToString() + " (" + allDevices + ")");
                gan_label.Text = ("Приборов ГАН: " + gan.ToString());
                notgan_label.Text = ("Приборов не ГАН: " + notgan.ToString());

                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            });
        }

        //--------------------------------------------------------------
        // Метод для рботы с PDF файлом
        //--------------------------------------------------------------
        private void PDF()
        {
            string oldFile = Application.StartupPath + @"\\Source\\PDF\\1.pdf";                                 // путь к исходному шаблону .pdf
            string newFile = Application.StartupPath + @"\\Source\\PDF\\2.pdf";                                 // путь экспорта заполненного .pdf

            PdfReader reader = new PdfReader(oldFile);                                                          // создаем ридер для iTextSharp
            iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            try
            {
                FileStream fileStream = new FileStream(newFile, FileMode.Create, FileAccess.Write);             // создаем экспортируемый файл
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();

                PdfContentByte contentByte = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(Application.StartupPath + @"\\Source\\Title\\timesbd.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);      // настройка шрифтов
                contentByte.SetColorFill(BaseColor.BLUE);
                contentByte.SetFontAndSize(bf, 12);

                contentByte.BeginText();                                                                        // пишем текст в новый .pdf

                string text = "106";                                                                            // Поле: Здание
                contentByte.ShowTextAligned(1, text, 170, 531, 0);                                              // длина, ширина, поворот
                contentByte.ShowTextAligned(1, text, 638, 531, 0);

                text = "УРБ";                                                                                   // Поле: служба
                contentByte.ShowTextAligned(1, text, 255, 519, 0);
                contentByte.ShowTextAligned(1, text, 723, 519, 0);

                text = Convert.ToString(dataGridView1.Rows[index].Cells[0].Value);                              // Поле: Табульный номер
                contentByte.ShowTextAligned(1, text, 170, 488, 0);
                contentByte.ShowTextAligned(1, text, 694, 488, 0);

                text = Convert.ToString(dataGridView1.Rows[index].Cells[1].Value);                              // Поле: Заводской номер
                contentByte.ShowTextAligned(1, text, 170, 458, 0);
                contentByte.ShowTextAligned(1, text, 694, 458, 0);

                text = Convert.ToString(dataGridView1.Rows[index].Cells[2].Value);                              // Поле: Тип
                contentByte.ShowTextAligned(1, text, 160, 420, 0);
                contentByte.ShowTextAligned(1, text, 684, 420, 0);

                text = Convert.ToString(dataGridView1.Rows[index].Cells[3].Value);                              // Поле: год выпуска
                contentByte.ShowTextAligned(1, text, 170, 351, 0);
                contentByte.ShowTextAligned(1, text, 694, 351, 0);

                if (test_radioButton.Checked)
                {
                    text = "___________";                                                                       // Поле: повеерка
                    contentByte.ShowTextAligned(1, text, 103, 136, 0);
                    contentByte.ShowTextAligned(1, text, 625, 136, 0);

                    text = "___________";                                                                       // Поле: по графику
                    contentByte.ShowTextAligned(1, text, 215, 148, 0);
                    contentByte.ShowTextAligned(1, text, 737, 148, 0);
                }

                if (repairs_radioButton.Checked)
                {
                    text = "___________";                                                                       // Поле: ремонт
                    contentByte.ShowTextAligned(1, text, 103, 124.3f, 0);
                    contentByte.ShowTextAligned(1, text, 625, 124.3f, 0);
                }
                if (entranceControl_radioButton.Checked)
                {
                    text = "____________";                                                                      // Поле: Входной контроль
                    contentByte.ShowTextAligned(1, text, 107, 112, 0);
                    contentByte.ShowTextAligned(1, text, 629, 112, 0);
                }

                string date = DateTime.Now.ToString("dd.MM.yyyy");
                text = Convert.ToString(date);
                contentByte.ShowTextAligned(1, text, 145, 41, 0);
                contentByte.ShowTextAligned(1, text, 672, 58, 0);

                contentByte.EndText();

                PdfImportedPage page = writer.GetImportedPage(reader, 1);
                contentByte.AddTemplate(page, 0, 0);

                document.Close();
                fileStream.Close();
                writer.Close();
                reader.Close();

                // меняем статус устройства на "Отправлен" и изменяем дату отправки
                dataGridView1.CurrentRow.Cells[4].Value = date;
                dataGridView1.CurrentRow.Cells[6].Value = "----";
                dataGridView1.CurrentRow.Cells[10].Value = 2;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("UPDATE " + tableName + " SET sentDate= '" + date + "', deviceLocation = '----', state= 2 WHERE personnelNumber= " + dataGridView1.CurrentRow.Cells[0].Value, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Файл уже используется");
            }
            finally
            {
                 PrintPdfFile();
            }
        }
        //---------------------------------------------------
        // Метод вывода на печать .pdf файла чрез Spire.PDF
        //---------------------------------------------------
        public void PrintPdfFile()
        {
            string newFile = Application.StartupPath + @"\\Source\\PDF\\2.pdf";                                 // путь экспорта заполненного .pdf

            Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();                                    // создаём экземпляр
            pdfdocument.LoadFromFile(newFile);                                                                  // загружаем файл

            //pdfdocument.PrinterName = "My Printer";

            pdfdocument.PrintDocument.PrinterSettings.Copies = 1;                                               // количество копий (можно не указывать)
            pdfdocument.PrintDocument.Print();
            pdfdocument.Dispose();

            ListMarking();
        }
        //---------------------------------------
        // получаем индекс выделенной строки
        //---------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
        }
        //------------------------------------
        // фильтр поиска в datagridview
        //------------------------------------
        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            if (search_textBox.Text != "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)")
            {
                try
                {
                    dataGridView1.CurrentCell = null;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if ((dataGridView1.Rows[i].Cells[0].Value.ToString() == "" + search_textBox.Text) || (dataGridView1.Rows[i].Cells[1].Value.ToString() == "" + search_textBox.Text) || (dataGridView1.Rows[i].Cells[7].Value.ToString() == "" + search_textBox.Text))            // Фильтр по Табельному номеру
                            dataGridView1.Rows[i].Visible = true;
                        else
                            dataGridView1.Rows[i].Visible = false;

                        if (search_textBox.Text == "")
                        {
                            dataGridView1.Rows[i].Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());

        }
        //------------------------------------
        // Удаление подсказки из textbox
        //------------------------------------
        private void search_textBox_Enter(object sender, EventArgs e)
        {
            if(search_textBox.Text == "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)")
            {
                search_textBox.TextChanged -= new System.EventHandler(search_textBox_TextChanged);      // Отписываемся от события TextChanged, что бы не дёргало таблицу
                search_textBox.Text = "";                                                               // Очищаем TextBox
                search_textBox.ForeColor = Color.Black;                                                 // Возвращаем системный текст
                search_textBox.TextChanged += new System.EventHandler(search_textBox_TextChanged);      // Подписываемся обратно после завершения очистки TextBox
            }
        }
        //------------------------------------
        // Добавление подсказки из textbox
        //------------------------------------
        private void search_textBox_Leave(object sender, EventArgs e)
        {
            if (search_textBox.Text == "")
            {
                search_textBox.Text = "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)";
                search_textBox.ForeColor = Color.Silver;
            }
        }

        //---------------------------------------
        // Фильтрация по ThreeView
        //---------------------------------------
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //***************************
            // Фильтры по типу устройств
            //***************************
            if (treeView1.Nodes[0].IsSelected)                                                             // Фильтр для УИМ
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                   dataGridView1.Rows[i].Visible = true;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            if (treeView1.Nodes[0].Nodes[0].IsSelected)                                                     // Фильтр для УИМ
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "УИМ2-2" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "УИМ2-2Д")
                        dataGridView1.Rows[i].Visible = false;
                    else
                        dataGridView1.Rows[i].Visible = true;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            if (treeView1.Nodes[0].Nodes[1].IsSelected)                                                     // Фильтр для БДАС
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДАС-03П")
                        dataGridView1.Rows[i].Visible = false;
                    else
                        dataGridView1.Rows[i].Visible = true;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            if (treeView1.Nodes[0].Nodes[2].IsSelected)                                                     // Фильтр для БДГБ
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДГБ-02П" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДГБ-02И" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДГБ-02П1")
                        dataGridView1.Rows[i].Visible = false;
                    else
                        dataGridView1.Rows[i].Visible = true;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            if (treeView1.Nodes[0].Nodes[3].IsSelected)                                                     // Фильтр для БДМГ
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДМГ41" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДМГ41-01" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДМГ41-03" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДМГ08Р-02" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДМГ08Р-04" && dataGridView1.Rows[i].Cells[2].Value.ToString() != "БДМГ08Р-05")
                        dataGridView1.Rows[i].Visible = false;
                    else
                        dataGridView1.Rows[i].Visible = true;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            if (treeView1.Nodes[0].Nodes[4].IsSelected)                                                     // Фильтр для УДАС
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Rows[i].Cells[2].Value.ToString() != "УДАС-03П") && (dataGridView1.Rows[i].Cells[2].Value.ToString() != "УДАС-02П" && (dataGridView1.Rows[i].Cells[2].Value.ToString() != "УДАБ-02П"))
                        dataGridView1.Rows[i].Visible = false;
                    else
                        dataGridView1.Rows[i].Visible = true;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            if (treeView1.Nodes[0].Nodes[5].IsSelected)                                                     // Фильтр для ДКГ
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Rows[i].Cells[2].Value.ToString() != "ДКГ-АТ2503") && (dataGridView1.Rows[i].Cells[2].Value.ToString() != "ДКГ-АТ2503А"))
                        dataGridView1.Rows[i].Visible = false;
                    else
                        dataGridView1.Rows[i].Visible = true;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //**********************************
            // Фильтр консервировнных устройств
            //**********************************

            // значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация

            if (treeView1.Nodes[3].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 4)                 // где 1 - отправлен, 0 - нет
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр готовящихся устройств
            //********************************
            if (treeView1.Nodes[1].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 5 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 7)                // где 5 - Прибор готовится на отправку
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр отправленных устройств
            //********************************
            if (treeView1.Nodes[4].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 2)                // где 1 - отправлен, 0 - нет
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр просроченных устройств
            //********************************
            if (treeView1.Nodes[2].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 1 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 6)                // где 1 - отправлен, 0 - нет
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр устройств на складе
            //********************************
            if (treeView1.Nodes[5].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 3 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 6 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 7)                // где 1 - отправлен, 0 - нет
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр устройств ГАН
            //********************************
            if (treeView1.Nodes[6].Nodes[0].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value) == true)                       // где true - ГАН, false - не ГАН
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }
            //********************************
            // Фильтр устройств не ГАН
            //********************************
            if (treeView1.Nodes[6].Nodes[1].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value) == false)                       // где true - ГАН, false - не ГАН
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

            //********************************
            // Фильтр списанных устройств
            //********************************
            if (treeView1.Nodes[6].Nodes[2].IsSelected)
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 8)                            // где 8 - списан
                        dataGridView1.Rows[i].Visible = true;
                    else
                        dataGridView1.Rows[i].Visible = false;
                }
                CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            }

        }

        //---------------------------------------
        // Экспорт видмых строк в .xml
        //---------------------------------------
        private void ExportToExcel()
        {
            Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = dataGridView1.Rows.Count;                                               // Назначаем прогресс бару range колличество строк
                progressBar1.Visible = true;                                                                   // делаем его видимым
            });
            //---------------------------------------------
            // Подготавливаем Excel файл под эксорт в него
            //---------------------------------------------

            try
            {
                ExcelDLL.Application excelApp = new ExcelDLL.Application();                                        // Создаем объект класса Application
                excelApp.Workbooks.Add();                                                                          // Создаем новую рабочую книгу (содержит 3 листа по умолчанию)
                ExcelDLL.Worksheet workSheet = (ExcelDLL.Worksheet)excelApp.ActiveSheet;                           // Получаем активный лист

                //---------------------------------------------
                // Заполняем заголовки колонок
                //---------------------------------------------

                workSheet.Cells[1, 1] = dataGridView1.Columns[0].HeaderText;
                workSheet.Cells[1, 2] = dataGridView1.Columns[1].HeaderText;
                workSheet.Cells[1, 3] = dataGridView1.Columns[2].HeaderText;
                workSheet.Cells[1, 4] = dataGridView1.Columns[3].HeaderText;
                workSheet.Cells[1, 5] = dataGridView1.Columns[4].HeaderText;
                workSheet.Cells[1, 6] = dataGridView1.Columns[5].HeaderText;
                workSheet.Cells[1, 7] = dataGridView1.Columns[6].HeaderText;
                workSheet.Cells[1, 8] = dataGridView1.Columns[7].HeaderText;
                workSheet.Cells[1, 9] = dataGridView1.Columns[8].HeaderText;

                //---------------------------------------------
                // Экспортируем из DataGridView в Excel
                //---------------------------------------------

                int rowExcel = 2;                                                                                   // начинаем со строки 2, т.к. в 1 заголовки (в excel счет с 1, а не с 0)
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Increment(1);                                                                      // увеличиваем прогресс бар
                });
                    if (dataGridView1.Rows[i].Visible)
                    {
                        workSheet.Cells[rowExcel, 1] = dataGridView1.Rows[i].Cells[0].Value;
                        workSheet.Cells[rowExcel, 2] = dataGridView1.Rows[i].Cells[1].Value;
                        workSheet.Cells[rowExcel, 3] = dataGridView1.Rows[i].Cells[2].Value;
                        workSheet.Cells[rowExcel, 4] = dataGridView1.Rows[i].Cells[3].Value;
                        workSheet.Cells[rowExcel, 5] = dataGridView1.Rows[i].Cells[4].Value;
                        workSheet.Cells[rowExcel, 6] = dataGridView1.Rows[i].Cells[5].Value;
                        workSheet.Cells[rowExcel, 7] = dataGridView1.Rows[i].Cells[6].Value;
                        workSheet.Cells[rowExcel, 8] = dataGridView1.Rows[i].Cells[7].Value;
                        workSheet.Cells[rowExcel, 9] = dataGridView1.Rows[i].Cells[8].Value;

                        ++rowExcel;
                    }
                }

                //--------------------------------------------
                // Настройка форматирвоания вывода
                //--------------------------------------------
                workSheet.Name = "Список приборов";

                workSheet.Cells.Font.Name = "Time New Roman";                                                       // используем нужный шрифт
                workSheet.Cells.Font.Size = 10;                                                                     // используемый нужный размер текста
                for (int i = 1; i < 10; i++)                                                                        // делаем заголовок жирным
                    (workSheet.Cells[1, i] as ExcelDLL.Range).Font.Bold = true;

                (workSheet.Cells as ExcelDLL.Range).HorizontalAlignment = ExcelDLL.XlHAlign.xlHAlignCenter;         // выравнивание вертикали по центру
                (workSheet.Cells as ExcelDLL.Range).VerticalAlignment = ExcelDLL.XlVAlign.xlVAlignCenter;           // выравнивание горизонтали по центру

                for (int i = 1; i < 10; i++)                                                                          // устанавливаем ширину колонки по содержимому
                    workSheet.Columns[i].AutoFit();

                // Сохраняем файл
                string username = Environment.UserName;                                                            // узнаем имя пользователя
                string pathToXmlFile = @"C:\Documents and Settings\" + username + @"\Desktop\Export";               // указываем путь до рабочего стола
                workSheet.SaveAs(pathToXmlFile);                                                                    // сохраняем файл

                excelApp.Quit();
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Visible = false;
                });
                MessageBox.Show("Экспорт завершен, файл с именем Export.xml расположен на рабочем столе");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Visible = false;
                });
                MessageBox.Show("Для работы требуется установленный Microsoft Office Excel\n\nКод ошибки: 0x80040154 (System.Runtime.InteropServices.COMException)");
            }
        }
        //----------------------------------------------------------------
        // Добавление прибора
        //----------------------------------------------------------------
        private void AddDevice_button_Click(object sender, EventArgs e)
        {
            Add_device AddDevice = new Add_device();
            AddDevice.Owner = this;
            AddDevice.Show();
        }
    }
}

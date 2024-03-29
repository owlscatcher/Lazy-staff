﻿using iTextSharp.text;
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
using StaffSRC.Classes;

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

        ListMarking listMarking = new ListMarking();
        Search Search = new Search();

        //-----------------------------------
        // Кнопка экспорта из DGV в Excel
        //-----------------------------------
        private void ExportToXml_button_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection();

            Thread exportToExcel = new Thread(ExportToExcel);
            exportToExcel.Start();
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
                    Setting_button.Enabled = true;
                }
                else
                {
                    groupBox2.Enabled = false;
                    Setting_button.Enabled = false;
                    administration = false;
                }
            }
            else
            {
                groupBox2.Enabled = false;
                Setting_button.Enabled = false;
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
            Setting_button.Enabled = false;
            printDateTimePicker.Checked = false;

        }

        //-----------------------------------
        // Событие изменение select состояния строки || количество выделенных приборов
        //-----------------------------------
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int visibleRowCount = dataGridView1.SelectedRows.OfType<DataGridViewRow>().Where(row => row.Visible).Count();
            CountStatusLabel_StatusPanel.Text = "Количество выделенных приборов: " + visibleRowCount.ToString();
        }

        //-----------------------------------
        // Событие окончания сортировки, обновление маркеровки
        //-----------------------------------
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            listMarking.Start(this);
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
        //---------------------------------
        // Добавление устройства
        //---------------------------------
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (administration == true)
            {
                Add_device AddDevice = new Add_device();
                AddDevice.Owner = this;
                AddDevice.Show();
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

                dataGridView1.Columns[11].HeaderText = "Дата Тех. Осв.";
                dataGridView1.Columns[11].MinimumWidth = 60;
                dataGridView1.Columns[11].Visible = true;

            });

            listMarking.Start(this);

            DateTime dateTime = DateTime.Now;
            SyncStatusLabel_StatusPanel.Text = "Последняя синхронизация: " + dateTime.ToString();
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

                string date;
                if (!printDateTimePicker.Checked)
                    date = DateTime.Now.ToString("dd.MM.yyyy");
                else
                    date = printDateTimePicker.Value.ToString("dd.MM.yyyy");
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
            catch (IOException)
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

            listMarking.Start(this);
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
            Search.Start(this, dataGridView1, search_textBox);
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
            int level = e.Node.Level;
            int index = e.Node.Index;

            Classes.TreeViewFilter treeViewFilter = new Classes.TreeViewFilter();
            treeViewFilter.Filter(this, level, index);
            ////***************************
            //// Фильтры по типу устройств
            ////***************************
            //if (treeView1.Nodes[0].IsSelected)                                                             // Фильтр для всех
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //       dataGridView1.Rows[i].Visible = true;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            //if (treeView1.Nodes[0].Nodes[0].IsSelected)                                                     // Фильтр для УИМ
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (!dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(treeView1.SelectedNode.Text.ToString()))
            //            dataGridView1.Rows[i].Visible = false;
            //        else
            //            dataGridView1.Rows[i].Visible = true;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            //if (treeView1.Nodes[0].Nodes[1].IsSelected)                                                     // Фильтр для БДАС
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (!dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(treeView1.SelectedNode.Text.ToString()))
            //            dataGridView1.Rows[i].Visible = false;
            //        else
            //            dataGridView1.Rows[i].Visible = true;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            //if (treeView1.Nodes[0].Nodes[2].IsSelected)                                                     // Фильтр для БДГБ
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (!dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(treeView1.SelectedNode.Text.ToString()))
            //            dataGridView1.Rows[i].Visible = false;
            //        else
            //            dataGridView1.Rows[i].Visible = true;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            //if (treeView1.Nodes[0].Nodes[3].IsSelected)                                                     // Фильтр для БДМГ
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (!dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(treeView1.SelectedNode.Text.ToString()))
            //            dataGridView1.Rows[i].Visible = false;
            //        else
            //            dataGridView1.Rows[i].Visible = true;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            //if (treeView1.Nodes[0].Nodes[4].IsSelected)                                                     // Фильтр для УДАС
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (!dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(treeView1.SelectedNode.Text.ToString()))
            //            dataGridView1.Rows[i].Visible = false;
            //        else
            //            dataGridView1.Rows[i].Visible = true;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            //if (treeView1.Nodes[0].Nodes[5].IsSelected)                                                     // Фильтр для ДКГ
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (!dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(treeView1.SelectedNode.Text.ToString()))
            //            dataGridView1.Rows[i].Visible = false;
            //        else
            //            dataGridView1.Rows[i].Visible = true;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            ////**********************************
            //// Фильтр консервировнных устройств
            ////**********************************

            //// значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация

            //if (treeView1.Nodes[3].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 4)                 // где 1 - отправлен, 0 - нет
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            ////********************************
            //// Фильтр готовящихся устройств
            ////********************************
            //if (treeView1.Nodes[1].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 5 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 7)                // где 5 - Прибор готовится на отправку
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            ////********************************
            //// Фильтр отправленных устройств
            ////********************************
            //if (treeView1.Nodes[4].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 2)                // где 1 - отправлен, 0 - нет
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            ////********************************
            //// Фильтр просроченных устройств
            ////********************************
            //if (treeView1.Nodes[2].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 1 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 6)                // где 1 - отправлен, 0 - нет
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            ////********************************
            //// Фильтр устройств на складе
            ////********************************
            //if (treeView1.Nodes[5].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 3 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 6 || Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 7)                // где 1 - отправлен, 0 - нет
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            ////********************************
            //// Фильтр устройств ГАН
            ////********************************
            //if (treeView1.Nodes[6].Nodes[0].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value) == true)                       // где true - ГАН, false - не ГАН
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}
            ////********************************
            //// Фильтр устройств не ГАН
            ////********************************
            //if (treeView1.Nodes[6].Nodes[1].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value) == false)                       // где true - ГАН, false - не ГАН
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

            ////********************************
            //// Фильтр списанных устройств
            ////********************************
            //if (treeView1.Nodes[6].Nodes[2].IsSelected)
            //{
            //    dataGridView1.CurrentCell = null;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) == 8)                            // где 8 - списан
            //            dataGridView1.Rows[i].Visible = true;
            //        else
            //            dataGridView1.Rows[i].Visible = false;
            //    }
            //    CountVisibleDevices_StatusLabel.Text = ("Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString());
            //}

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
                workSheet.Cells[1, 10] = dataGridView1.Columns[11].HeaderText;

                //---------------------------------------------
                // Экспортируем из DataGridView в Excel
                //---------------------------------------------
                workSheet.Range["A1:B" + (dataGridView1.Rows.OfType<DataGridViewRow>().Where(row => row.Visible).Count() + 1)].NumberFormat = "@";    // форматируем столбцы, что бы не терять 0 у БДГБ

                int rowExcel = 2;                                                                                   // начинаем со строки 2, т.к. в 1 заголовки (в excel счет с 1, а не с 0)
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Increment(1);                                                                  // увеличиваем прогресс бар
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
                        workSheet.Cells[rowExcel, 10] = dataGridView1.Rows[i].Cells[11].Value;

                        ++rowExcel;
                    }
                }

                //--------------------------------------------
                // Настройка форматирвоания вывода
                //--------------------------------------------
                workSheet.Name = "Список приборов";

                workSheet.Cells.Font.Name = "Time New Roman";                                                       // используем нужный шрифт
                workSheet.Cells.Font.Size = 10;                                                                     // используемый нужный размер текста

                for (int i = 1; i < 11; i++)                                                                        // делаем заголовок жирным
                    (workSheet.Cells[1, i] as ExcelDLL.Range).Font.Bold = true;

                (workSheet.Cells as ExcelDLL.Range).HorizontalAlignment = ExcelDLL.XlHAlign.xlHAlignCenter;         // выравнивание вертикали по центру
                (workSheet.Cells as ExcelDLL.Range).VerticalAlignment = ExcelDLL.XlVAlign.xlVAlignCenter;           // выравнивание горизонтали по центру

                var rng = workSheet.Range["A1:J" + 
                    (dataGridView1.Rows.OfType<DataGridViewRow>().Where(row => row.Visible).Count() + 1)];          // Указание области границ таблицы
                rng.Borders.LineStyle = 1;                                                                          // Стиль границ
                rng.Borders.ColorIndex = 0;                                                                         // Цвет
                rng.Borders.TintAndShade = 0;
                rng.Borders.Weight = 2;                                                                             // Толщина линии

                for (int i = 1; i < 11; i++)                                                                          // устанавливаем ширину колонки по содержимому
                    workSheet.Columns[i].AutoFit();

                // Сохраняем файл
                string username = Environment.UserName;                                                             // узнаем имя пользователя
                DateTime dateTime = DateTime.Now;
                string pathToXmlFile = (@"C:\Documents and Settings\" + username + @"\Desktop\Export " + 
                    dateTime.ToString("dd-MM-yyyy") + "");                                                          // указываем путь до рабочего стола и именуем файл
                workSheet.SaveAs(pathToXmlFile);                                                                    // сохраняем файл

                excelApp.Quit();
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Visible = false;
                });
                MessageBox.Show("Экспорт завершен, файл с именем Export " + dateTime.ToString("dd-MM-yyyy") + ".xmlx расположен на рабочем столе");
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
    }
}

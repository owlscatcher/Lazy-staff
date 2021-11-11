using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSRC
{
    public partial class ReplaceDevice : Form
    {
        Classes.Search Search = new Classes.Search();
        string date = DateTime.Now.ToString("dd.MM.yyyy");

        public ReplaceDevice()
        {
            InitializeComponent();

            // Включаем двойную буферизацию для DataGridView2
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic 
                | System.Reflection.BindingFlags.Instance 
                | System.Reflection.BindingFlags.SetProperty,
                null,
                dataGridView2,
                new object[] { true });

            Print_chechBox.Checked = true;
            manualDate_dateTimePicker.Enabled = false;

            manualDate_dateTimePicker.CustomFormat = "MMMM dd, yyyy - dddd";
            manualDate_dateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void ReplaceDevice_Load(object sender, EventArgs e)
        {
            Staff_MainForm main = this.Owner as Staff_MainForm;

            manualDate_dateTimePicker.Value = DateTime.Now;

            dataGridView1.Rows.Add();

            dataGridView1.CurrentRow.Cells[0].Value = main.personnelNumber;
            dataGridView1.CurrentRow.Cells[1].Value = main.factoryNumber;
            dataGridView1.CurrentRow.Cells[2].Value = main.deviceType;
            dataGridView1.CurrentRow.Cells[3].Value = main.yearOfIssue;
            dataGridView1.CurrentRow.Cells[4].Value = main.sentDate;
            dataGridView1.CurrentRow.Cells[5].Value = main.verificationDate;
            dataGridView1.CurrentRow.Cells[6].Value = main.deviceLocation;
            dataGridView1.CurrentRow.Cells[7].Value = main.verifiedTo;
            dataGridView1.CurrentRow.Cells[8].Value = main.solutionNumber;
            dataGridView1.CurrentRow.Cells[10].Value = main.state;
            dataGridView1.CurrentRow.Cells[9].Value = main.gan_state;

            dataGridView2.DataSource = main.dataTable;

            // настройка вида отображаемых колонок           0 - Таб. №, 1 - Завод. №, 2 - Тип устройства, 3 - Год выпуска, 4 - Дата отправки, 5 - Дата ГП, 6 - Расположение, 7 - Продление
            dataGridView2.Columns[0].HeaderText = "Таб. №";
            dataGridView2.Columns[0].MinimumWidth = 30;

            dataGridView2.Columns[1].HeaderText = "Завод. №";
            dataGridView2.Columns[1].MinimumWidth = 30;

            dataGridView2.Columns[2].HeaderText = "Тип устройства";
            dataGridView2.Columns[2].MinimumWidth = 40;

            dataGridView2.Columns[3].HeaderText = "Год выпуска";
            dataGridView2.Columns[3].MinimumWidth = 40;

            dataGridView2.Columns[4].HeaderText = "Дата отправки";

            dataGridView2.Columns[5].HeaderText = "Дата ГП";

            dataGridView2.Columns[6].HeaderText = "Расположение";
            dataGridView2.Columns[6].MinimumWidth = 50;

            dataGridView2.Columns[7].HeaderText = "Продление";
            dataGridView2.Columns[7].MinimumWidth = 55;

            dataGridView2.Columns[8].HeaderText = "Тех. решение";
            dataGridView2.Columns[8].MinimumWidth = 60;

            dataGridView2.Columns[9].HeaderText = "ГАН";
            dataGridView2.Columns[9].MinimumWidth = 60;
            dataGridView2.Columns[9].Visible = false;

            dataGridView2.Columns[10].HeaderText = "Состояние";
            dataGridView2.Columns[10].MinimumWidth = 60;
            dataGridView2.Columns[10].Visible = false;
        }
        //------------------------------------
        // фильтр поиска в datagridview
        //------------------------------------
        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            Search.Start(this, dataGridView2, search_textBox);
        }
        //------------------------------------
        // Удаление подсказки из textbox
        //------------------------------------
        private void search_textBox_Enter(object sender, EventArgs e)
        {
            if (search_textBox.Text == "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)")
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

        private void Print_chechBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Print_chechBox.Checked)
                test_radioButton.Checked = true;
            else
            {
                test_radioButton.Checked = false;
                repairs_radioButton.Checked = false;
                entranceControl_radioButton.Checked = false;
            }
        }

        private void Replace_button_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                Staff_MainForm main = this.Owner as Staff_MainForm;

                SqlConnection connection = new SqlConnection(main.connectionString);

                // значения stage: 0 - норма (установлен, поверен), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервации, 5 - готовится к отправке
                //                 6 - просрочен и на складе, 7 - готовится к отправке и на складе, 8 - списан

                // dataGridView1.Rows[i].Cells[10].Value - stage (состояние прибора)
                // dataGridView1.Rows[i].Cells[5].Value  - дата гос.поверки
                // dataGridView1.Rows[i].Cells[6].Value - Расположение

                if (Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value) != "")
                {
                    dataGridView2.CurrentRow.Cells[6].Value = dataGridView1.CurrentRow.Cells[6].Value;

                    dataGridView1.CurrentRow.Cells[4].Value = date;
                    dataGridView1.CurrentRow.Cells[6].Value = "----";
                    dataGridView1.CurrentRow.Cells[10].Value = 2;   // 2 - state (отправлен)
                    SqlCommand command = new SqlCommand("UPDATE " + main.tableName + " SET sentDate= '" + date + "', deviceLocation = '----', state= 2 WHERE personnelNumber= " + dataGridView1.CurrentRow.Cells[0].Value, connection);

                    dataGridView2.CurrentRow.Cells[10].Value = 0;   // 0 - state (установлен)
                    SqlCommand command2 = new SqlCommand("UPDATE " + main.tableName + " SET deviceLocation = '" + Convert.ToString(dataGridView2.CurrentRow.Cells[6].Value) + "', state= 0 WHERE personnelNumber= " + dataGridView2.CurrentRow.Cells[0].Value, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();

                    connection.Close();
                    connection.Dispose();
                }
                else
                {
                    string message = "Не указано расположение первого прибора. \nВсё равно внести изменения?";
                    string caption = "Подтверждение:";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        dataGridView2.CurrentRow.Cells[6].Value = dataGridView1.CurrentRow.Cells[6].Value;

                        dataGridView1.CurrentRow.Cells[4].Value = date;
                        dataGridView1.CurrentRow.Cells[6].Value = "----";
                        dataGridView1.CurrentRow.Cells[10].Value = 2;   // 2 - state (отправлен)
                        SqlCommand command = new SqlCommand("UPDATE " + main.tableName + " SET sentDate= '" + date + "', deviceLocation = '----', state= 2 WHERE personnelNumber= " + dataGridView1.CurrentRow.Cells[0].Value, connection);

                        dataGridView2.CurrentRow.Cells[10].Value = 0;   // 0 - state (установлен)
                        SqlCommand command2 = new SqlCommand("UPDATE " + main.tableName + " SET deviceLocation = '" + Convert.ToString(dataGridView2.CurrentRow.Cells[6].Value) + "', state= 0 WHERE personnelNumber= " + dataGridView2.CurrentRow.Cells[0].Value, connection);

                        connection.Open();
                        command.ExecuteNonQuery();
                        command2.ExecuteNonQuery();

                        connection.Close();
                        connection.Dispose();
                    }

                    else
                        return;
                }

                if (Print_chechBox.Checked)
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

                        text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);                              // Поле: Табульный номер
                        contentByte.ShowTextAligned(1, text, 170, 488, 0);
                        contentByte.ShowTextAligned(1, text, 694, 488, 0);

                        text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);                              // Поле: Заводской номер
                        contentByte.ShowTextAligned(1, text, 170, 458, 0);
                        contentByte.ShowTextAligned(1, text, 694, 458, 0);

                        text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);                              // Поле: Тип
                        contentByte.ShowTextAligned(1, text, 160, 420, 0);
                        contentByte.ShowTextAligned(1, text, 684, 420, 0);

                        text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);                              // Поле: год выпуска
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
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Файл уже используется");
                    }
                    finally
                    {
                        main.PrintPdfFile();
                    }
                }

                main.DataGridView_Load();
                main.dataGridView1.Refresh();

                Close();
            }
            else
                MessageBox.Show("Выберите устройство из второй таблицы, которым требуется заменить");
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        //------------------------------------------------------
        // настройка ввода даты вручну
        //------------------------------------------------------
        private void ManualDate_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (manualDate_checkBox.Checked)
            {
                manualDate_dateTimePicker.Enabled = true;
                date = manualDate_dateTimePicker.Value.ToString("dd.MM.yyyy");
            }
            else
            {
                manualDate_dateTimePicker.Enabled = false;
                date = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }
        private void ManualDate_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (manualDate_checkBox.Checked)
                date = manualDate_dateTimePicker.Value.ToString("dd.MM.yyyy");
            else
                date = DateTime.Now.ToString("dd.MM.yyyy");
        }
    }
}

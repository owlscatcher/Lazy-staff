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
    public partial class Form1 : Form
    {
        public String connectionString, staff;
        public String[] _tabel_n, _zavod_n, _tipe, _year_relis, _date_otprv, _date_gp, _point, _prodlenie, _tehreshenie;
        Props props = new Props();
        public Form1()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------
        //Поиск файла настроек
        //----------------------------------------------------------------
        private void FileSearch()
        {
            if (!File.Exists(Environment.CurrentDirectory + "\\settings.xml"))      //определяем существование файла
            //если не нашли
            {
                MessageBox.Show("Файл настроек не найден.");
                _tabel_n = new string[1];
                _tabel_n[0] = tabel_n;
               

            }
            else
            //если нашли
            {
                props.ReadXml();                                                    //подключаем класс для считывания настроек из файла
                //порт
                tabe = props.Fields.TextValue1;                                   //записываем сохраненную настройку в переменную
                comport = cmport.Split(';');                                        //разбиваем строку на элементы в массив

                connectionString = props.Fields.TextValue1;                                    //записываем сохраненную настройку в переменную
                staff = props.Fields.TextValue2;
            }
        }

        //----------------------------------------------------------------------------
        // Загрузка данных в DataGridView
        //----------------------------------------------------------------------------
        private void _DGW_Fill()
        {
            while (dataGridView1.Rows.Count > 0)                                // Пока есть строки в массиве
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);           // очищаем datagrid
                }

            SqlConnection connection = new SqlConnection(connectionString);
            string querry = ("SELECT * FROM " + staff + "");              // запрос к sql db на получение строк
            SqlDataAdapter dataAdapter = new SqlDataAdapter(querry, connection);    // создаем экземпляр dataAdapter для получения строк из sql db
            DataSet dataSet = new DataSet();                                        // создаем экземпляр dataset

            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                string message = "Не удалось подклюиться к базе данных.";   // Формировани текста окна ошибки
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;        // Формирование кнопок Да/Нет
                DialogResult result;                                        // В какую переменную вывести 
                result = MessageBox.Show(message, caption, buttons);        // Вывод диалогового окна
                if (result == System.Windows.Forms.DialogResult.Yes)        // Если нажмем кнопку Да
                {
                    Options Option = new Options();                         // Открыть окно настроек
                    Option.Show();
                }
            }

            dataAdapter.Fill(dataSet, "Monitor");                           // помещаем строки в dataset
            connection.Close();                                             // закрываем соединение
            dataGridView1.DataSource = dataSet;                             // заводим источик данный
            dataGridView1.DataMember = "Monitor";                           // создаем DataMemder

            // настройка вида отображаемых колонок           
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[0].MinimumWidth = 30;
            dataGridView1.Columns[0].Width = 35;

            dataGridView1.Columns[1].HeaderText = "УНО";
            dataGridView1.Columns[1].MinimumWidth = 30;
            dataGridView1.Columns[1].Width = 35;

            dataGridView1.Columns[2].HeaderText = "Состояние";
            dataGridView1.Columns[2].MinimumWidth = 40;
            dataGridView1.Columns[2].Width = 45;

            dataGridView1.Columns[3].HeaderText = "Точка контроля";
            dataGridView1.Columns[3].MinimumWidth = 40;
            dataGridView1.Columns[3].Width = 45;

            dataGridView1.Columns[4].HeaderText = "Название детектора";
            dataGridView1.Columns[4].Visible = false;

            dataGridView1.Columns[5].HeaderText = "Расположение";
            dataGridView1.Columns[5].Visible = false;

            dataGridView1.Columns[6].HeaderText = "Значение";
            dataGridView1.Columns[6].MinimumWidth = 50;
            dataGridView1.Columns[6].Width = 55;

            dataGridView1.Columns[7].HeaderText = "Размерность";
            dataGridView1.Columns[7].MinimumWidth = 55;
            dataGridView1.Columns[7].Width = 60;

            dataGridView1.Columns[8].HeaderText = "Дата";
            dataGridView1.Columns[8].MinimumWidth = 60;
            dataGridView1.Columns[8].Width = 65;

            dataGridView1.Columns[9].HeaderText = "On-Off";
            dataGridView1.Columns[9].Visible = false;

            dataGridView1.Columns[10].HeaderText = "Категория";
            dataGridView1.Columns[10].MinimumWidth = 70;
            dataGridView1.Columns[10].Visible = false;

            dataGridView1.Columns[11].HeaderText = "Коэффицент";
            dataGridView1.Columns[11].MinimumWidth = 70;
            dataGridView1.Columns[11].Width = 75;

            dataGridView1.Columns[12].HeaderText = "Пред-аварийная уставка";
            dataGridView1.Columns[12].MinimumWidth = 70;
            dataGridView1.Columns[12].Width = 75;

            dataGridView1.Columns[13].HeaderText = "Аварийная уставка";
            dataGridView1.Columns[12].MinimumWidth = 70;
            dataGridView1.Columns[12].Width = 75;

            dataGridView1.Columns[14].HeaderText = "Статус";
        }
    }
}

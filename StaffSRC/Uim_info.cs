using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSRC
{
    public partial class Uim_info : Form
    {
        public Uim_info()
        {
            InitializeComponent();
        }

        private void Uim_info_Load(object sender, EventArgs e)
        {
            UimGridLoad();
            RoomGridLoad();
        }
        //-------------------------------
        // Заполнение таблицы по УИМ
        //-------------------------------
        private void UimGridLoad()
        {
            while (uimInfo_DataGridView.Rows.Count > 0)                                                                // Пока есть строки в массиве
                for (int i = 0; i < uimInfo_DataGridView.Rows.Count; i++)
                {
                    uimInfo_DataGridView.Rows.Remove(uimInfo_DataGridView.Rows[i]);                                    // очищаем datagrid
                }
            string connectionString = @"Server=192.168.20.83\SPORTAPP;Database=106_staff;User Id=root;Password=1234";  // для подключения к удаленному серверу
            string tableName = "[106_staff].[dbo].[uim_info]";
            SqlConnection connection = new SqlConnection(connectionString);
            string querry = ("SELECT * FROM " + tableName + "");                                                // запрос к sql db на получение строк
            SqlDataAdapter dataAdapter = new SqlDataAdapter(querry, connection);                                // создаем экземпляр dataAdapter для получения строк из sql db                                                           // создаем экземпляр dataset

            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                string message = "Не удалось подклюиться к базе данных.";                                       // Формировани текста окна ошибки
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;                                            // Формирование кнопок Да/Нет
                DialogResult result;                                                                            // В какую переменную вывести 
                result = MessageBox.Show(message, caption, buttons);                                            // Вывод диалогового окна
                if (result == System.Windows.Forms.DialogResult.Yes)                                            // Если нажмем кнопку Да
                {
                    Options Option = new Options();                                                             // Открыть окно настроек
                    Option.Show();
                }
            }
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataSet, "UIM");                                                                   // помещаем строки в dataSet, называем таблицу Monitor
            dataTable = dataSet.Tables["UIM"].Copy();
            connection.Close();                                                                                 // закрываем соединение
            uimInfo_DataGridView.DataSource = dataTable;                                                        // заводим источик данный

            // настройка вида отображаемых колонок           
            uimInfo_DataGridView.Columns[0].HeaderText = "Таб. №";
            uimInfo_DataGridView.Columns[0].MinimumWidth = 30;

            uimInfo_DataGridView.Columns[1].HeaderText = "Завод. №";
            uimInfo_DataGridView.Columns[1].MinimumWidth = 30;

            uimInfo_DataGridView.Columns[2].HeaderText = "Тип розетки";
            uimInfo_DataGridView.Columns[2].MinimumWidth = 40;
        }

        //-------------------------------
        // Заполнение таблицы по помещениям
        //-------------------------------
        private void RoomGridLoad()
        {
            while (roomPowerSocketInfo_DataGridView.Rows.Count > 0)                                                    // Пока есть строки в массиве
                for (int i = 0; i < roomPowerSocketInfo_DataGridView.Rows.Count; i++)
                {
                    roomPowerSocketInfo_DataGridView.Rows.Remove(roomPowerSocketInfo_DataGridView.Rows[i]);            // очищаем datagrid
                }
            string connectionString = @"Server=192.168.20.83\SPORTAPP;Database=106_staff;User Id=root;Password=1234";  // для подключения к удаленному серверу
            string tableName = "[106_staff].[dbo].[room_info]";
            SqlConnection connection = new SqlConnection(connectionString);
            string querry = ("SELECT * FROM " + tableName + "");                                                // запрос к sql db на получение строк
            SqlDataAdapter dataAdapter = new SqlDataAdapter(querry, connection);                                // создаем экземпляр dataAdapter для получения строк из sql db                                                           // создаем экземпляр dataset

            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                string message = "Не удалось подклюиться к базе данных.";                                       // Формировани текста окна ошибки
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;                                            // Формирование кнопок Да/Нет
                DialogResult result;                                                                            // В какую переменную вывести 
                result = MessageBox.Show(message, caption, buttons);                                            // Вывод диалогового окна
                if (result == System.Windows.Forms.DialogResult.Yes)                                            // Если нажмем кнопку Да
                {
                    Options Option = new Options();                                                             // Открыть окно настроек
                    Option.Show();
                }
            }
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataSet, "ROOM");                                                                  // помещаем строки в dataSet, называем таблицу Monitor
            dataTable = dataSet.Tables["ROOM"].Copy();
            connection.Close();                                                                                 // закрываем соединение
            roomPowerSocketInfo_DataGridView.DataSource = dataTable;                                            // заводим источик данный

            // настройка вида отображаемых колонок           
            roomPowerSocketInfo_DataGridView.Columns[0].HeaderText = "Помещение";
            roomPowerSocketInfo_DataGridView.Columns[0].MinimumWidth = 30;

            roomPowerSocketInfo_DataGridView.Columns[1].HeaderText = "Тип розетки";
            roomPowerSocketInfo_DataGridView.Columns[1].MinimumWidth = 30;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace StaffSRC
{
    class VerificationList
    {
        public DataSet dataSet = new DataSet();
        public DataTable dataTable = new DataTable();

        public void Start(int dateFrom, int dateTo)
        {

            string writePath = Application.StartupPath + @"\\Source\\1.txt";
            string querry = ("SELECT [personnelNumber], [factoryNumber], [deviceType] FROM [staff_106].[dbo].[staff] WHERE [verifiedTo] = '1 кв. 2020' AND [deviceType] = 'УИМ2-2' AND [state] != 4 AND [gan] = 1");

            ConnectionToSQL connection = new ConnectionToSQL();
            SqlConnection conn = connection.GetConnection();
            connection.ConnectionOpen();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(querry, conn);
            dataAdapter.Fill(dataSet, "Monitor");
            dataTable = dataSet.Tables["Monitor"].Copy();
            connection.ConnectionClose();

            if (!File.Exists(writePath))
                File.Create(Application.StartupPath + @"\\Source\\1.txt");

            try
            {
                StreamWriter streamWriter = new StreamWriter(writePath, false, System.Text.Encoding.Default);
                streamWriter.WriteLine(dataSet.ToString());
                streamWriter.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

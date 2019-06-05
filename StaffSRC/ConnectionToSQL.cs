using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StaffSRC.Properties;

namespace StaffSRC
{
    class ConnectionToSQL
    {
        static string connectionString = Settings.Default["connectionString"].ToString();
        readonly SqlConnection connection = new SqlConnection(connectionString);

        public SqlConnection GetConnection()
        {
            return connection;
        }
        public void ConnectionOpen()
        {
            connection.Open();
        }
        public void ConnectionClose()
        {
            connection.Close();
        }
    }
}

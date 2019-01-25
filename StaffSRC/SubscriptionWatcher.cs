using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffSRC
{
    class SubscriptionWatcher
    {
        public string tableNameWatcher = "", connectionStr = "";

        public void StartWatching(string connectionString, string tableName)
        {
            tableNameWatcher = tableName;
            connectionStr = connectionString;

            SqlDependency.Stop(connectionStr);
            SqlDependency.Start(connectionStr);
            ExecuteWatcherQuery();
        }

        private void ExecuteWatcherQuery()
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT personnelNumber, factoryNumber, deviceType, yearOfIssue, sentDate, verificationDate, deviceLocation, verifiedTo, solutionNunber, conservation, sent, overdue, storage, gan FROM " + tableNameWatcher + "", connection))
                {
                    var sqlDependency = new SqlDependency(command);
                    sqlDependency.OnChange += new OnChangeEventHandler(OnDatabaseChange);
                    command.ExecuteReader();
                }
            }
        }

        private void OnDatabaseChange(object sender, SqlNotificationEventArgs args)
        {
            SqlNotificationInfo info = args.Info;
            if (SqlNotificationInfo.Insert.Equals(info) 
                || SqlNotificationInfo.Update.Equals(info) 
                || SqlNotificationInfo.Delete.Equals(info))
            {
                Staff_MainForm main = new Staff_MainForm();
                main.DataGridView_Load();
            }
            ExecuteWatcherQuery();
        }
    }
}

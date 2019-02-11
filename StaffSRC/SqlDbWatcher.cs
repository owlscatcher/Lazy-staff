using StaffSRC.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffSRC
{
    class SqlDbWatcher
    {
        static string queueName = "dbo.ServiceBrokerQueue";
        static string connectionString = Settings.Default["connectionString"].ToString();
        SqlConnection connection = new SqlConnection (connectionString);

        void SomeMethod()
        {
            // Assume connection is an open SqlConnection.

            // Create a new SqlCommand object.
            using (SqlCommand command = new SqlCommand("SELECT factoryNumber, deviceType, yearOfIssue, " +
                "sentDate, verificationDate, deviceLocation, verifiedTo, solutionNunber, gan, state FROM dbo.staff_106", connection))
            {

                // Create a dependency and associate it with the SqlCommand.
                SqlDependency dependency = new SqlDependency(command);
                // Maintain the refence in a class member.

                // Subscribe to the SqlDependency event.
                dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);

                // Execute the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Process the DataReader.
                }
            }
        }

        // Handler method
        void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the event (for example, invalidate this cache entry).

        }

        void Termination()
        {
            SqlDependency.Stop(connectionString, queueName);
        }
    }
}

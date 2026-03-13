using LazyStaff.Models;
using Npgsql;
using System;

namespace LazyStaff
{
    class DatabaseConnection
    {
        private static readonly Lazy<DatabaseConnection> _instance =
            new Lazy<DatabaseConnection>(() => new DatabaseConnection());

        public static DatabaseConnection Instance => _instance.Value;

        public NpgsqlConnection Connection { get; }

        private DatabaseConnection()
        {
            var settings = new DatabaseConnectionSettings();
            Connection = new NpgsqlConnection(settings.ConnectionString);
        }
    }
}

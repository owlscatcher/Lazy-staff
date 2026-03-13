using LazyStaff.Helpers;

namespace LazyStaff.Models
{
    class DatabaseConnectionSettings
    {
        public string Host { get; }
        public string DatabaseName { get; }
        public string User { get; }
        public string Password { get; }
        public string DeviceTable { get; }

        public DatabaseConnectionSettings()
        {
            Host = SettingsVariable.GetValue(Constants.DbHostEnv);
            DatabaseName = SettingsVariable.GetValue(Constants.DbNameEnv);
            User = SettingsVariable.GetValue(Constants.DbUserEnv);
            Password = SettingsVariable.GetValue(Constants.DbPasswordEnv);
            DeviceTable = SettingsVariable.GetValue(Constants.DbDeviceTableEnv);
        }

        public string ConnectionString =>
            $"Host={Host};Database={DatabaseName};Username={User};Password={Password};";
    }
}

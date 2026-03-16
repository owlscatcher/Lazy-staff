using System.Globalization;

namespace LazyStaff.Helpers
{
    static class Constants
    {
        public const string DbHostEnv = "LAZYSTAFF_DB_HOST";
        public const string DbNameEnv = "LAZYSTAFF_DB_NAME";
        public const string DbUserEnv = "LAZYSTAFF_DB_USER";
        public const string DbPasswordEnv = "LAZYSTAFF_DB_PASSWORD";
        public const string DbDeviceTableEnv = "LAZYSTAFF_DB_DEVICE_TABLE";

        /// <summary>Формат даты для обмена и отображения (инвариантная культура).</summary>
        public const string DateFormat = "dd.MM.yyyy";
        /// <summary>Формат даты и времени для отображения.</summary>
        public const string DateTimeFormat = "dd.MM.yyyy HH:mm";

        public static readonly IFormatProvider Invariant = CultureInfo.InvariantCulture;
    }
}

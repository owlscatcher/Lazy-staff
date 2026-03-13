using System;
using System.Windows.Forms;

namespace LazyStaff
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Инициализация единственного подключения к базе данных при старте приложения
            var _ = DatabaseConnection.Instance;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Staff_MainForm());
        }
    }
}

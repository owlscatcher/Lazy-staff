using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace LazyStaff
{
    public class Property
    {
        public string XmlFileName = Application.StartupPath + "\\settings.xml";

        // Что бы добавить настройку в программу, добавить строку вида
        // public ТИП ИМЯ_ПЕРЕМЕННОЙ = значение_переменной_по_умолчанию
        public string TextValue = @"Server=192.168.20.83\SPORTAPP;Database=staff_106;User Id=root;Password=1234";
    }

    // Класс для работы с настройками
    public class Props
    {
    }
}

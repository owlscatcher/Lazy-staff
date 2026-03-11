using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyStaff.Classes
{
    class PrintDevice
    {
        public string TabelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public string YearOfRelease { get; set; }
        public string DateToPrint { get; set; }
        public bool IsRepairType { get; set; }
        public bool IsMetrologicalControlType { get; set; }
        public MetrologicalControlType McSelected { get; set; }
        public RepairType RepairSelected { get; set; }

    }
}

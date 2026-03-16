using System;

namespace LazyStaff.Models
{
    /// <summary>
    /// Состояние прибора. Числовые значения хранятся в БД (колонка state) и в DataGridView (колонка 10).
    /// Менять значения нельзя — должны совпадать с предыдущей реализацией и ListMarking.
    /// </summary>
    public enum Status
    {
        Normal = 0,
        Overdue = 1,
        Sended = 2,
        InStock = 3,
        Canned = 4,
        PreparingForSend = 5,
        OverdueAndInStock = 6,
        PreparingForSendAndInStock = 7,
        WrittenOff = 8
    }
 
	public class Device
	{
        public int Id { get; set; }
        public string SerialId { get; set; }
        public string DeviceTypeName { get; set; }
        public int ReleaseYear { get; set; }
        public string Loaction { get; set; }
        public int Status { get; set; }
        public DateTime DateOfShipment { get; set; }
        public DateTime DateCheck { get; set; }
        public string ValidTo { get; set; }
        public string Solution { get; set; }
        public bool IsGun { get; set; }
        public string DateOfTechnicalInspection { get; set; }
        public int MetrologicalControlInterval { get; set; }

        public Device()
		{
		}
	}
}

using System;

namespace LazyStaff.Models
{
    enum Status
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
        public int SerialId { get; set; }
        public int DeviceTypeId { get; set; }
        public int ReleaseYear { get; set; }
        public string Loaction { get; set; }
        public int Status { get; set; }
        public DateTime DateOfShipment { get; set; }
        public DateTime DateCheck { get; set; }
        public DateTime ValidTo { get; set; }
        public string Solution { get; set; }
        public bool IsGun { get; set; }
        public DateTime DateOfTechnicalInspection { get; set; }

        public Device()
		{
		}
	}
}

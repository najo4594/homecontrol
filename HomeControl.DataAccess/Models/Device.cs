using System.ComponentModel.DataAnnotations.Schema;

namespace HomeControl.DataAccess.Models
{
	public class Device
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int DeviceId { get; set; }

		[Column("Room_Id")]
		public int RoomId { get; set; }
		
		public Room Room { get; set; }

		[Column("DeviceType_Id")]
		public int DeviceTypeId { get; set; }

		public DeviceType Type { get; set; }
	}
}
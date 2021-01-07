using System.Collections.Generic;

namespace HomeControl.DataAccess.Models
{
	public class Room
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int RoomId { get; set; }
		
		public List<Device> Devices { get; set; }
	}
}
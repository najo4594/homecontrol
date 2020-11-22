namespace HomeControl.DataAccess.Models
{
	public class Device
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int RoomId { get; set; }
		
		public Room Room { get; set; }
	}
}
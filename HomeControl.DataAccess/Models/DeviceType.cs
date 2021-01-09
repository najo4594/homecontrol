using System.Collections.Generic;

namespace HomeControl.DataAccess.Models
{
	public class DeviceType
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Device> Devices { get; set; }
	}
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeControl.DataAccess.Models
{
	[Table("DeviceTypes")]
	public class DeviceType
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Device> Devices { get; set; }
	}
}
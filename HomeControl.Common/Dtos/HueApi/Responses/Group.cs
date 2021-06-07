using System.Collections.Generic;

namespace HomeControl.Common.Dtos.HueApi.Responses
{
	public class Group
	{
		public string Name { get; set; }

		public string Type { get; set; }

		public IEnumerable<int> Lights { get; set; }
	}
}
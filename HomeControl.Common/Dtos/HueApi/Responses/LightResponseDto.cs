using System.Collections.Generic;

namespace HomeControl.Common.Dtos.HueApi.Responses
{
	public class LightResponseDto
	{
		public IDictionary<int, LightItemResponseDto> Items { get; set; }
	}
}
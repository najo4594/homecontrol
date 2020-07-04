namespace HomeControl.Common.Dtos.HueApi.Responses
{
	public class LightItemResponseDto
	{
		public string Name { get; set; }

		public LightStateResponseDto State { get; set; }
	}
}
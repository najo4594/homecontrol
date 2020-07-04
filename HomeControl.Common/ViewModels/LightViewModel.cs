namespace HomeControl.Common.ViewModels
{
	public class LightViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public LightStateViewModel State { get; set; }
	}
}
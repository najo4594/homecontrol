namespace HomeControl.Service.HueApi
{
	public interface IHueApi
	{
		T Get<T>(string resourcePath);
	}
}
using System.Collections.Generic;
using System.Linq;
using HomeControl.Common.Dtos.HueApi.Responses;
using HomeControl.Service.HttpClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HomeControl.Service.HueApi
{
	public class HueApi : IHueApi
	{
		private readonly IHttpClient _httpClient;
		private readonly string _bridgeIp;
		private readonly string _userName;

		public HueApi(IConfiguration configuration, IHttpClient httpClient)
		{
			_httpClient = httpClient;
			_bridgeIp = GetBridgeIp(configuration);
			_userName = GetUser(configuration);
		}

		public T Get<T>(string resourcePath)
		{
			string resourceUrl = GetResourceUrl(resourcePath);

			string responseString = _httpClient.Get(resourceUrl);

			return JsonConvert.DeserializeObject<T>(responseString);
		}

		private string GetBridgeIp(IConfiguration configuration)
		{
			string url = configuration["HueApi:DiscoverUrl"];

			string responseString = _httpClient.Get(url);

			return JsonConvert.DeserializeObject<IEnumerable<BridgeDiscoverResponse>>(responseString).FirstOrDefault()?.InternalIpAddress;
		}

		private string GetResourceUrl(string resourcePath)
		{
			return $"http://{_bridgeIp}/api/{_userName}/{resourcePath}";
		}

		private string GetUser(IConfiguration configuration)
		{
			return configuration["HueApi:Username"];
		}
	}
}
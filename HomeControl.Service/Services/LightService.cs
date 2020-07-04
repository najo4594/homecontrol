using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HomeControl.Common.Dtos.HueApi.Responses;
using HomeControl.Common.ViewModels;
using HomeControl.Service.Interfaces;
using Newtonsoft.Json;

namespace HomeControl.Service.Services
{
	public class LightService : ILightService
	{
		public async Task<IEnumerable<LightViewModel>> GetAllLights()
		{
			var discoverUrl = "https://discovery.meethue.com";

			var discoverResponse = await Get<IEnumerable<BridgeDiscoverResponse>>(discoverUrl);

			string lightStateUrl = $"http://{discoverResponse.FirstOrDefault()?.InternalIpAddress}/api/37jkmbWO2SbtGLs3hx-Y614lH8s8Sv3pw70HsvFl/lights";

			var lightsResponse = await Get<IDictionary<int, LightItemResponseDto>>(lightStateUrl);

			return lightsResponse.Select(s => new LightViewModel { Id = s.Key, Name = s.Value.Name, State = new LightStateViewModel { On = s.Value.State.On } });
		}

		private async Task<T> Get<T>(string url)
		{
			using (var client = new HttpClient())
			using (HttpResponseMessage res = await client.GetAsync(url))
			using (HttpContent content = res.Content)
			{
				string responseData = await content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(responseData);
			}
		}
	}
}
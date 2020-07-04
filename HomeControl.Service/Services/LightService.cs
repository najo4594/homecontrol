using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeControl.Common.Dtos.HueApi.Responses;
using HomeControl.Common.ViewModels;
using HomeControl.Service.HueApi;
using HomeControl.Service.Services.Interfaces;

namespace HomeControl.Service.Services
{
	public class LightService : ILightService
	{
		private readonly IHueApi _hueApi;

		public LightService(IHueApi hueApi)
		{
			_hueApi = hueApi;
		}

		public IEnumerable<LightViewModel> GetAllLights()
		{
			var lightsResponse = _hueApi.Get<IDictionary<int, LightItemResponseDto>>("lights");

			return lightsResponse.Select(s => new LightViewModel { Id = s.Key, Name = s.Value.Name, State = new LightStateViewModel { On = s.Value.State.On } });
		}
	}
}
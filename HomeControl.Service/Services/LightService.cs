using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeControl.Common.Dtos.HueApi.Responses;
using HomeControl.Common.ViewModels;
using HomeControl.DataAccess;
using HomeControl.Service.HueApi;
using HomeControl.Service.Services.Interfaces;

namespace HomeControl.Service.Services
{
	public class LightService : ILightService
	{
		private readonly IHueApi _hueApi;
		private readonly IHomeControlRepository _homeControlRepository;

		public LightService(IHueApi hueApi, IHomeControlRepository homeControlRepository)
		{
			_hueApi = hueApi;
			_homeControlRepository = homeControlRepository;
		}

		public async Task<IEnumerable<DeviceViewModel>> GetAllLights()
		{
			var devices = await _homeControlRepository.GetAllDevices().ConfigureAwait(false);

			var lightsResponse = _hueApi.Get<IDictionary<int, LightItemResponseDto>>("lights");

			return devices.Select(
				s => new DeviceViewModel
				{
					Id = s.Id, 
					Name = s.Name, 
					RoomId = s.RoomId,
					State = new LightStateViewModel
					{
						On = lightsResponse[s.Id].State.On
					}
				});
		}
	}
}
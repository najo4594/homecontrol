using System.Collections.Generic;
using System.Threading.Tasks;
using HomeControl.Common.Dtos.HueApi.Responses;
using HomeControl.Common.ViewModels;

namespace HomeControl.Service.Interfaces
{
	public interface ILightService
	{
		Task<IEnumerable<LightViewModel>> GetAllLights();
	}
}
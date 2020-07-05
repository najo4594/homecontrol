using System.Collections.Generic;
using System.Threading.Tasks;
using HomeControl.Common.ViewModels;

namespace HomeControl.Service.Services.Interfaces
{
	public interface ILightService
	{
		Task<IEnumerable<DeviceViewModel>> GetAllLights();
	}
}
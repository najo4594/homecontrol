using System.Collections.Generic;
using HomeControl.Common.ViewModels;

namespace HomeControl.Service.Services.Interfaces
{
	public interface ILightService
	{
		IEnumerable<LightViewModel> GetAllLights();
	}
}
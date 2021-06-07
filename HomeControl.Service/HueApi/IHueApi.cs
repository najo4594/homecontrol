using System.Collections.Generic;
using HomeControl.Common.Dtos.HueApi.Responses;

namespace HomeControl.Service.HueApi
{
	public interface IHueApi
	{
		IDictionary<int, Group> GetAllGroups();

		IDictionary<int, Light> GetAllLights();
	}
}
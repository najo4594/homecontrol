using System.Collections.Generic;
using HomeControl.Common.Dtos.HueApi.Responses;

namespace HomeControl.Service.HueApi
{
	public interface IHueApi
	{
		IDictionary<int, GroupResponse> GetAllGroups();
	}
}
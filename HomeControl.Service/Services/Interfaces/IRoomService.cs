using System.Collections.Generic;
using HomeControl.Common.ViewModels;

namespace HomeControl.Service.Services.Interfaces
{
	public interface IRoomService
	{
		IEnumerable<RoomViewModel> GetAllRooms();

		IEnumerable<DeviceViewModel> GetDevicesForRoom(int roomId);
	}
}
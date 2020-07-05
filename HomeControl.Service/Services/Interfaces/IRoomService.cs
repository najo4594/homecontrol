using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeControl.Common.ViewModels;

namespace HomeControl.Service.Services.Interfaces
{
	public interface IRoomService
	{
		Task<IEnumerable<RoomViewModel>> GetAllRooms();
	}
}
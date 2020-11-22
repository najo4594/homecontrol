using System.Collections.Generic;
using System.Threading.Tasks;
using HomeControl.DataAccess.Models;

namespace HomeControl.DataAccess
{
	public interface IHomeControlRepository
	{
		Task<List<Device>> GetAllDevices();

		Task<List<Room>> GetAllRooms();
	}
}
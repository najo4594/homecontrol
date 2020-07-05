using System.Collections.Generic;
using System.Threading.Tasks;
using HomeControl.DataAccess.Models;

namespace HomeControl.DataAccess
{
	public interface IHomeControlRepository
	{
		Task<Device> GetDeviceById(int id);

		Task<List<Device>> GetAllDevices();
	}
}
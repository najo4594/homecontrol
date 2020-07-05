using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeControl.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeControl.DataAccess
{
	public class HomeControlRepository : IHomeControlRepository
	{
		private readonly HomeControlContext _context;

		public HomeControlRepository(HomeControlContext context)
		{
			_context = context;
		}

		public Task<Device> GetDeviceById(int id)
		{
			return _context.Devices.Where(r => r.Id == id).FirstOrDefaultAsync();
		}

		public Task<List<Device>> GetAllDevices()
		{
			return _context.Devices.ToListAsync();
		}
	}
}
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

		public Task<List<Device>> GetAllDevices()
		{
			return _context.Devices.ToListAsync();
		}

		public Task<List<Room>> GetAllRooms()
		{
			return _context.Rooms.ToListAsync();
		}

		public Task<List<Device>> GetDevicesForRoom(int roomId)
		{
			return _context.Devices.Where(r => r.Room.RoomId == roomId).ToListAsync();
		}
	}
}
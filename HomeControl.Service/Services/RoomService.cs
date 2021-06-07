using System.Collections.Generic;
using System.Linq;
using HomeControl.Common.ViewModels;
using HomeControl.DataAccess;
using HomeControl.DataAccess.Models;
using HomeControl.Service.Services.Interfaces;

namespace HomeControl.Service.Services
{
	public class RoomService : IRoomService
	{
		private readonly HomeControlContext _context;

		public RoomService(HomeControlContext context)
		{
			_context = context;
		}

		public IEnumerable<RoomViewModel> GetAllRooms()
		{
			List<Room> rooms = _context.Rooms.ToList();

			return rooms.Select(s => new RoomViewModel { Id = s.Id, Name = s.Name });
		}

		public IEnumerable<DeviceViewModel> GetDevicesForRoom(int roomId)
		{
			List<Device> devices = _context.Devices.Where(r => r.Room.RoomId == roomId).ToList();

			return devices.Select(s => new DeviceViewModel { Id = s.Id, Name = s.Name, RoomId = s.RoomId, TypeId = s.TypeId });
		}
	}
}
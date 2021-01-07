using System.Collections.Generic;
using System.Linq;
using HomeControl.Common.Dtos.HueApi.Responses;
using HomeControl.Common.Enums;
using HomeControl.DataAccess;
using HomeControl.DataAccess.Models;
using HomeControl.Service.HueApi;
using HomeControl.Service.Services.Interfaces;

namespace HomeControl.Service.Services
{
	public class SynchronizationService : ISynchronizationService
	{
		private readonly IHueApi _hueApi;
		private readonly HomeControlContext _context;

		public SynchronizationService(IHueApi hueApi, HomeControlContext context)
		{
			_hueApi = hueApi;
			_context = context;
		}

		public void Synchronize()
		{
			IDictionary<int, GroupResponse> groups = _hueApi.GetAllGroups();
			IDictionary<int, GroupResponse> rooms = groups
				.Where(r => r.Value.Type == GroupTypes.Room.ToString())
				.ToDictionary(d => d.Key, d => d.Value);

			List<Room> existingRooms = _context.Rooms.ToList();

			foreach (int roomId in rooms.Keys)
			{
				GroupResponse roomFromApi = rooms[roomId];

				Room roomToSave = existingRooms.FirstOrDefault(r => r.RoomId == roomId);

				if (roomToSave == null)
				{
					roomToSave = new Room { RoomId = roomId };
					_context.Rooms.Add(roomToSave);
				}

				roomToSave.Name = roomFromApi.Name;
			}
			_context.SaveChanges();
		}
	}
}
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
			IDictionary<int, Group> groups = _hueApi.GetAllGroups()
				.Where(r => r.Value.Type == GroupTypes.Room.ToString())
				.ToDictionary(d => d.Key, d => d.Value);

			List<Room> rooms = SynchronizeRooms(groups);
			SynchronizeDevices(groups, rooms);
			_context.SaveChanges();
		}

		private List<Room> SynchronizeRooms(IDictionary<int, Group> groups)
		{
			List<Room> rooms = _context.Rooms.ToList();

			foreach (int groupId in groups.Keys)
			{
				Group group = groups[groupId];

				Room roomToSave = rooms.FirstOrDefault(r => r.RoomId == groupId);

				if (roomToSave == null)
				{
					roomToSave = new Room { RoomId = groupId };
					_context.Rooms.Add(roomToSave);
					rooms.Add(roomToSave);
				}

				roomToSave.Name = group.Name;
			}

			return rooms;
		}

		private void SynchronizeDevices(IDictionary<int, Group> groups, List<Room> rooms)
		{
			IDictionary<int, Light> lights = _hueApi.GetAllLights();
			List<Device> existingDevices = _context.Devices.ToList();

			foreach (int lightId in lights.Keys)
			{
				Light light = lights[lightId];

				Device deviceToSave = existingDevices.FirstOrDefault(r => r.DeviceId == lightId);
				int groupId = groups.FirstOrDefault(r => r.Value.Lights.Contains(lightId)).Key;
				Room room = rooms.FirstOrDefault(r => r.RoomId == groupId);

				if (deviceToSave == null)
				{
					deviceToSave = new Device { DeviceId = lightId, Room = room };
					_context.Devices.Add(deviceToSave);
				}

				deviceToSave.Name = light.Name;
			}
		}
	}
}
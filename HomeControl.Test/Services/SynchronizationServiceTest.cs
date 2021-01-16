using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using HomeControl.Common.Dtos.HueApi.Responses;
using HomeControl.Common.Enums;
using HomeControl.DataAccess.Models;
using HomeControl.Service.HueApi;
using HomeControl.Service.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using DeviceType = HomeControl.DataAccess.Models.DeviceType;

namespace HomeControl.Test.Services
{
	public class SynchronizationServiceTest : ServiceTestBase
	{
		private readonly IDictionary<int, Group> _groupsFromApi = new Dictionary<int, Group>
		{
			{ 1, new Group { Name = "Updated Room 1", Type = GroupType.Room.ToString(), Lights = new List<int> { 1, 2 } } },
			{ 2, new Group { Name = "New Room 2", Type = GroupType.Room.ToString(), Lights = new List<int> { 3, 4 } } },
			{ 3, new Group { Name = "Unknown Group 3", Type = "Unknown Group Type", Lights = new List<int> { 5, 6 } } }
		};

		private readonly IDictionary<int, Light> _lightsFromApi = new Dictionary<int, Light>
		{
			{ 1, new Light { Name = "Updated Light 1", Type = "Extended color light" } },
			{ 2, new Light { Name = "New Socket 2", Type = "On/Off plug-in unit" } },
			{ 3, new Light { Name = "New Light 3", Type = "Color temperature light" } },
			{ 4, new Light { Name = "New Light 4", Type = "Dimmable light" } },
			{ 5, new Light { Name = "Updated Light 5", Type = "Extended color light" } },
			{ 6, new Light { Name = "Updated Socket 6", Type = "On/Off plug-in unit" } }
		};

		private readonly List<Room> _expectedRoomsResult = new List<Room>
		{
			new Room { Id = 1, RoomId = 1, Name = "Updated Room 1" },
			new Room { Id = 2, RoomId = 2, Name = "New Room 2" },
		};

		private readonly List<Device> _expectedDevicesResult = new List<Device>
		{
			new Device { Id = 1, DeviceId = 1, Name = "Updated Light 1", TypeId = (int)Common.Enums.DeviceType.Light, RoomId = 1 },
			new Device { Id = 2, DeviceId = 2, Name = "New Socket 2", TypeId = (int)Common.Enums.DeviceType.Socket, RoomId = 1 },
			new Device { Id = 3, DeviceId = 3, Name = "New Light 3", TypeId = (int)Common.Enums.DeviceType.Light, RoomId = 2 },
			new Device { Id = 4, DeviceId = 4, Name = "New Light 4", TypeId = (int)Common.Enums.DeviceType.Light, RoomId = 2 },
		};

		private IHueApi _hueApi;
		private SynchronizationService _synchronizationService;

		[SetUp]
		public void SetUp()
		{
			_hueApi = A.Fake<IHueApi>(f => f.Strict());

			_synchronizationService = new SynchronizationService(_hueApi, Context);

			A.CallTo(() => _hueApi.GetAllGroups()).Returns(_groupsFromApi);
			A.CallTo(() => _hueApi.GetAllLights()).Returns(_lightsFromApi);

			var existingDeviceTypeLight = new DeviceType { Id = (int)Common.Enums.DeviceType.Light };
			var existingDeviceTypeSocket = new DeviceType { Id = (int)Common.Enums.DeviceType.Socket };
			Context.DeviceTypes.AddRange(existingDeviceTypeLight, existingDeviceTypeSocket);

			var existingRoom = new Room { RoomId = 1, Name = "Existing Room 1" };
			Context.Rooms.Add(existingRoom);

			var existingDevice = new Device { Name = "Existing Light 1", DeviceId = 1, Room = existingRoom, Type = existingDeviceTypeLight };
			Context.Devices.Add(existingDevice);

			Context.SaveChanges();
		}

		[Test]
		public void Synchronize()
		{
			// Act
			_synchronizationService.Synchronize();

			// Assert
			List<Room> roomsResult = Context.Rooms.ToList();
			roomsResult.Should().BeEquivalentTo(_expectedRoomsResult, options => options.Excluding(e => e.Devices));
			List<Device> devicesResult = Context.Devices.ToList();
			devicesResult.Should().BeEquivalentTo(devicesResult);
		}
	}
}
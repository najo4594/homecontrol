using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HomeControl.Common.ViewModels;
using HomeControl.DataAccess.Models;
using HomeControl.Service.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace HomeControl.Test.Services
{
	public class RoomServiceTest : ServiceTestBase
	{
		private RoomService _roomService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			Context.DeviceTypes.AddRange(
				new DeviceType { Id = 1, Name = "Type 1" },
				new DeviceType { Id = 2, Name = "Type 2" },
				new DeviceType { Id = 3, Name = "Type 3" });
			Context.SaveChanges();
		}

		[SetUp]
		public void SetUp()
		{
			_roomService = new RoomService(Context);
		}

		[TearDown]
		public void TearDown()
		{
			Context.Database.ExecuteSqlRaw("DELETE FROM Devices");
			Context.Database.ExecuteSqlRaw("DELETE FROM Rooms");
		}

		[Test]
		public void GetAllRooms_NoRoomsExisting()
		{
			// Act
			List<RoomViewModel> result = _roomService.GetAllRooms().ToList();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeEmpty();
		}

		[Test]
		public void GetAllRooms_RoomsExisting()
		{
			// Arrange
			var roomOne = new Room { Name = "Room 1", RoomId = 1 };
			var roomTwo = new Room { Name = "Room 2", RoomId = 2 };
			Context.Rooms.AddRange(roomOne, roomTwo);
			Context.SaveChanges();

			var expectedResult = new List<RoomViewModel>
			{
				new RoomViewModel { Id = roomOne.Id, Name = roomOne.Name },
				new RoomViewModel { Id = roomTwo.Id, Name = roomTwo.Name },
			};

			// Act
			List<RoomViewModel> result = _roomService.GetAllRooms().ToList();

			// Assert
			result.Should().BeEquivalentTo(expectedResult);
		}

		[Test]
		public void GetDevicesForRoom_NoRoomsAndDevicesExisting()
		{
			// Act
			List<DeviceViewModel> result = _roomService.GetDevicesForRoom(1).ToList();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeEmpty();
		}

		[Test]
		public void GetDevicesForRoom_RoomsButNoDevicesExisting()
		{
			// Arrange
			var roomOne = new Room { Name = "Room 1", RoomId = 1 };
			var roomTwo = new Room { Name = "Room 2", RoomId = 2 };
			Context.Rooms.AddRange(roomOne, roomTwo);
			Context.SaveChanges();
			
			// Act
			List<DeviceViewModel> result = _roomService.GetDevicesForRoom(roomOne.RoomId).ToList();
			
			// Assert
			result.Should().NotBeNull();
			result.Should().BeEmpty();
		}

		[Test]
		public void GetDevicesForRoom_RoomsAndDevicesExisting()
		{
			// Arrange
			var roomOne = new Room { Name = "Room 1", RoomId = 1 };
			var roomTwo = new Room { Name = "Room 2", RoomId = 2 };
			Context.Rooms.AddRange(roomOne, roomTwo);
			var deviceOne = new Device { Name = "Device 1", DeviceId = 1, Room = roomOne, TypeId = 1 };
			var deviceTwo = new Device { Id = 2, Name = "Device 2", DeviceId = 2, Room = roomOne, TypeId = 2 };
			var deviceThree = new Device { Id = 3, Name = "Device 3", DeviceId = 3, Room = roomTwo, TypeId = 3 };
			Context.Devices.AddRange(deviceOne, deviceTwo, deviceThree);
			Context.SaveChanges();

			var expectedResult = new List<DeviceViewModel>
			{
				new DeviceViewModel { Id = deviceOne.Id, Name = deviceOne.Name, RoomId = roomOne.Id, TypeId = deviceOne.TypeId },
				new DeviceViewModel { Id = deviceTwo.Id, Name = deviceTwo.Name, RoomId = roomOne.Id, TypeId = deviceTwo.TypeId },
			};

			// Act
			List<DeviceViewModel> result = _roomService.GetDevicesForRoom(roomOne.RoomId).ToList();

			// Assert
			result.Should().BeEquivalentTo(expectedResult);
		}
	}
}
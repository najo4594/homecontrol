using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using HomeControl.Common.ViewModels;
using HomeControl.Service.Services.Interfaces;
using HomeControl.Web.Controllers;
using NUnit.Framework;

namespace HomeControl.Test.Controllers
{
	public class RoomsControllerTest
	{
		private IRoomService _roomService;
		private RoomsController _roomsController;

		[SetUp]
		public void SetUp()
		{
			_roomService = A.Fake<IRoomService>(f => f.Strict());
			_roomsController = new RoomsController(_roomService);
		}

		[Test]
		public void GetAllRooms()
		{
			// Arrange
			var rooms = new List<RoomViewModel>
			{
				new RoomViewModel { Id = 1, Name = "Room 1" },
				new RoomViewModel { Id = 2, Name = "Room 2" }
			};
			A.CallTo(() => _roomService.GetAllRooms()).Returns(rooms);

			// Act
			IEnumerable<RoomViewModel> result = _roomsController.GetAllRooms();

			// Assert
			result.Should().BeEquivalentTo(rooms);
		}

		[Test]
		public void Devices()
		{
			// Arrange
			var roomId = 1;
			var devices = new List<DeviceViewModel>
			{
				new DeviceViewModel { Id = 1, Name = "Device 1", RoomId = 2, TypeId = 3 },
				new DeviceViewModel { Id = 4, Name = "Device 4", RoomId = 5, TypeId = 6 }
			};
			A.CallTo(() => _roomService.GetDevicesForRoom(roomId)).Returns(devices);

			// Act
			IEnumerable<DeviceViewModel> result = _roomsController.Devices(roomId);

			// Assert
			result.Should().BeEquivalentTo(devices);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeControl.Common.ViewModels;
using HomeControl.DataAccess.Models;
using HomeControl.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoomsController : ControllerBase
	{
		private readonly IRoomService _roomService;

		public RoomsController(IRoomService roomService)
		{
			_roomService = roomService;
		}

		[HttpGet]
		public Task<IEnumerable<RoomViewModel>> GetAllRooms()
		{
			return _roomService.GetAllRooms();
		}

		[HttpGet]
		[Route("[Action]")]
		public Task<IEnumerable<DeviceViewModel>> Devices([FromQuery] int roomId)
		{
			return _roomService.GetDevicesForRoom(roomId);
		}
	}
}
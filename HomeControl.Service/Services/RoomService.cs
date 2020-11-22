using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeControl.Common.ViewModels;
using HomeControl.DataAccess;
using HomeControl.DataAccess.Models;
using HomeControl.Service.Services.Interfaces;

namespace HomeControl.Service.Services
{
	public class RoomService : IRoomService
	{
		private readonly IHomeControlRepository _homeControlRepository;

		public RoomService(IHomeControlRepository homeControlRepository)
		{
			_homeControlRepository = homeControlRepository;
		}

		public async Task<IEnumerable<RoomViewModel>> GetAllRooms()
		{
			List<Room> rooms = await _homeControlRepository.GetAllRooms().ConfigureAwait(false);

			return rooms.Select(s => new RoomViewModel { Id = s.Id, Name = s.Name }).ToList();
		}
	}
}
using HomeControl.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SynchronizationController : ControllerBase
	{
		private readonly ISynchronizationService _synchronizationService;

		public SynchronizationController(ISynchronizationService synchronizationService)
		{
			_synchronizationService = synchronizationService;
		}

		[HttpGet]
		public void Synchronize()
		{
			_synchronizationService.Synchronize();
		}
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeControl.Common.ViewModels;
using HomeControl.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LightsController : ControllerBase
	{
		private readonly ILightService _lightService;

		public LightsController(ILightService lightService)
		{
			_lightService = lightService;
		}

		[HttpGet]
		public Task<IEnumerable<LightViewModel>> GetAllLights()
		{
			return _lightService.GetAllLights();
		}
	}
}
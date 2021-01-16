using FakeItEasy;
using HomeControl.Service.Services.Interfaces;
using HomeControl.Web.Controllers;
using NUnit.Framework;

namespace HomeControl.Test.Controllers
{
	public class SynchronizationControllerTest
	{
		private ISynchronizationService _synchronizationService;
		private SynchronizationController _synchronizationController;

		[SetUp]
		public void SetUp()
		{
			_synchronizationService = A.Fake<ISynchronizationService>(f => f.Strict());
			
			_synchronizationController = new SynchronizationController(_synchronizationService);

			A.CallTo(() => _synchronizationService.Synchronize()).DoesNothing();
		}
		
		[Test]
		public void Synchronize()
		{
			// Act
			_synchronizationController.Synchronize();
			
			// Assert
			A.CallTo(() => _synchronizationService.Synchronize()).MustHaveHappenedOnceExactly();
		}
	}
}
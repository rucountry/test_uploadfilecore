using Microsoft.AspNetCore.Mvc;
using System.Threading;
using TestMVC.Infrastructure.Filters;

namespace TestMVC.Controllers
{
	
	public class HomeFilterController : Controller
	{
		[IsHttpsOnlyFilter]
		public IActionResult IsHttpsOnly()
		{
			return View();
		}

		[SimpleActionFilter]
		public IActionResult SimpleAction()
		{
			return Content("Simple action");
		}

		[SimpleAsyncActionFilter]
		public IActionResult SimpleAsyncAction()
		{
			Thread.Sleep(3000);
			return Content("Simple async action");
		}

		//[TypeFilter(typeof(DiagnosticFilterWithDI))]
		//[TypeFilter(typeof(TimeFilterWithDI))]
		[ServiceFilter(typeof(DiagnosticFilterWithDI))]
		[ServiceFilter(typeof(TimeFilterWithDI))]
		public IActionResult GybridFilterWithDI()
		{
			return View();
		}
	}
}
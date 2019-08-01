using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMVC.Models;

namespace TestMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger _logger;
		public HomeController(ILogger<HomeController> _logger)
		{
			this._logger = _logger;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddFile(IFormFile file)
		{
			_logger.LogInformation("Выполнение метода AddFile");
			if (file != null)
			{
				_logger.LogInformation("Файл имеет размер {0}",file.Length);

				var filePath = Path.GetTempFileName();
				_logger.LogInformation("Файл сохраняем {0}", filePath);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				_logger.LogInformation("Файл сохранен");
			}
			else
				_logger.LogInformation("Файл не существует");
			return RedirectToAction("Index");
		}
	}
}

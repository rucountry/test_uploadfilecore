using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
		// Загрузка файла
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
				_logger.LogInformation("Файл имеет размер {0}", file.Length);

				byte[] img = new byte[file.Length];
				using (var stream = new MemoryStream(img))
				{
					await file.CopyToAsync(stream);
					_logger.LogInformation("Записали поток в MemoryStream");
					try
					{
						_logger.LogInformation("Создаем Bitmap image");
						using (Bitmap bitmap = new Bitmap(stream))
						{
							_logger.LogInformation("Bitmap image создан");

							Bitmap bmnew = Watermark.WaterMarkToImage(bitmap, "test text");

							if (bmnew != null && !bmnew.Size.IsEmpty)
							{
								bmnew.Save("wwwroot/i2.jpg");
								_logger.LogInformation("Файл сохранен");
							}
							else
								_logger.LogInformation("Ошибка обработки Watermark");
						}
					}
					catch (Exception e)
					{
						_logger.LogInformation("Bitmap image не создан");
						_logger.LogInformation(e.Message);
					}
				}
			}
			else
				_logger.LogInformation("Файл не существует");
			return RedirectToAction("Index");
		}
	}
}

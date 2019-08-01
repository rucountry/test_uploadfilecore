using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddFile(IFormFile file)
		{
			if (file != null)
			{
				var filePath = Path.GetTempFileName();
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
			}

			return RedirectToAction("Index");
		}
	}
}

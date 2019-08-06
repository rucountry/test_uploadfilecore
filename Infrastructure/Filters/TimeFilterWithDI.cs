using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestMVC.Infrastructure.Services;

namespace TestMVC.Infrastructure.Filters
{
	public class TimeFilterWithDI : IAsyncActionFilter, IAsyncResultFilter
	{
		private readonly IFilterDiagnostics diagnostics;
		private Stopwatch timer;
		public TimeFilterWithDI(IFilterDiagnostics diagnostics)
		{
			this.diagnostics = diagnostics ?? throw new ArgumentException("diagnostics is null");
		}
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			timer = Stopwatch.StartNew();
			await next();
			diagnostics.AddMessage($"Action generate = {timer.Elapsed.Milliseconds}");
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			await next();
			timer.Stop();
			diagnostics.AddMessage($"Result generate = {timer.Elapsed.Milliseconds}");
		}

	}
}

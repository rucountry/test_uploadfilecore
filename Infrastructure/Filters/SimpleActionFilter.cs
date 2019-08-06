using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Text;

namespace TestMVC.Infrastructure.Filters
{
	public class SimpleActionFilter : ActionFilterAttribute
	{
		private Stopwatch timer;
		// Метод, который выполняется перед выполнением Action
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			timer = Stopwatch.StartNew();
		}

		// Метод, который выполняется после выполнения Action
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			timer.Stop();
			string result = $"Time {timer.ElapsedMilliseconds.ToString()} ms";
			byte[] bytes = Encoding.ASCII.GetBytes(result);
			context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
		}
	}
}

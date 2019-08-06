using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TestMVC.Infrastructure.Filters
{
	public class SimpleAsyncActionFilter : ActionFilterAttribute
	{
		private Stopwatch timer;
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			timer = Stopwatch.StartNew();
			await next();
			timer.Stop();
			string result = $"Time async {timer.ElapsedMilliseconds.ToString()} ms";
			byte[] bytes = Encoding.ASCII.GetBytes(result);
			await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}
	}
}

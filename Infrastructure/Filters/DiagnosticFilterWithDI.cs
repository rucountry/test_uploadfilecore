using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVC.Infrastructure.Services;

namespace TestMVC.Infrastructure.Filters
{
	public class DiagnosticFilterWithDI : IAsyncResultFilter
	{
		private readonly IFilterDiagnostics diagnostics;
		public DiagnosticFilterWithDI(IFilterDiagnostics diagnostics)
		{
			this.diagnostics = diagnostics ?? throw new ArgumentException("diagnostics is null");
		}
		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			await next();

			foreach (var item in diagnostics?.Messages)
			{
				byte[] bytes = Encoding.ASCII.GetBytes("<div>"+item+"</div>");
				await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
			}
		}
	}
}

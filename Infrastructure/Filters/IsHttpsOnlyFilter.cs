using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace TestMVC.Infrastructure.Filters
{
	public class IsHttpsOnlyFilterAttribute : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (!context.HttpContext.Request.IsHttps)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
			}
		}
	}
}

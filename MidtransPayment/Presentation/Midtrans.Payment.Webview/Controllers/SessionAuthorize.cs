using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Midtrans.Payment.Webview.Helpers;

namespace Midtrans.Payment.Webview.Controllers
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class SessionAuthorize : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			bool auth = HelperClient.GetCookies(context.HttpContext.Request);
			if (!auth)
				context.Result = new RedirectResult("~/Account/Logoff");
		}

	}
}

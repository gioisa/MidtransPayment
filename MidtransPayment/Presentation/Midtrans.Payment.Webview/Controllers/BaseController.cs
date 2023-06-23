using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Midtrans.Payment.Webview.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Midtrans.Payment.Webview.Controllers
{
	[SessionAuthorize]
	public class BaseController<T> : Controller
	{
		private IRestAPIHelper _apiHelperInstance;
		private ILogger<T> _loggerInstance;
		protected IRestAPIHelper _apiHelper => _apiHelperInstance ??= HttpContext.RequestServices.GetService<IRestAPIHelper>();
		protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var token = HelperClient.GetToken(HttpContext.Request);
			if (!token.Success)
			{
				context.Result = RedirectToAction("Login", "Account", new { Area = "" });
				return;
			}
			List<string> exclude = new List<string>()
			{
				"/",
				"/Home/Privacy",
				"/Home/Error",
                //"/Notification/Index",
                "#"
			};
			//var permissions = await _apiHelper.Permissions(token.Result.User.Role.Id);
			//if (permissions.succeeded)
			//    ViewBag.Permission = permissions.list;

			//var page = await _apiHelper.Page(token.Result.User.Role.Id);
			//if (page.Succeeded)
			//{
			//	if (!exclude.Any(d => d == Request.Path.Value))
			//	{
			//		bool found = false;
			//		foreach (var m in page.Data.Pages)
			//		{
			//			var check_page = CheckCurrentPage(Request.Path.Value, m.Pages);
			//			found = check_page.found;
			//			if (check_page.found)
			//			{
			//				ViewBag.CurrentPageId = check_page.id.Value;
			//				ViewBag.CurrentParentPageId = check_page.parent_id;
			//				break;
			//			}
			//		}
			//		if (!found)
			//		{
			//			context.Result = RedirectToAction("Forbidden", "Home", new { Area = "" });
			//			return;
			//		}
			//	}
			//}
			await base.OnActionExecutionAsync(context, next);
			ViewBag.User = token.Result.User;
			//ViewBag.Page = page.Data.Pages;
			//var console_log = System.Text.Json.JsonSerializer.Serialize(page.Data.Pages);
			//Console.WriteLine(console_log);

		}

		private (int? id, int? parent_id, bool found) CheckCurrentPage(string navigation, List<Models.PageModel> pages)
		{
			foreach (var p in pages)
			{
				if (checkPage(navigation, p.Navigation))
					return (p.Id, null, true);

				foreach (var cc in p.Childs)
				{
					if (checkPage(navigation, cc.Navigation))
						return (cc.Id, p.Id, true);

					foreach (var a in cc.Additional)
					{
						if (checkPage(navigation, a.Navigation))
							return (cc.Id, p.Id, true);
					}
				}

				foreach (var a in p.Additional)
				{
					if (checkPage(navigation, a.Navigation))
						return (p.Id, null, true);
				}



			}
			return (null, null, false);
		}
		private bool checkPage(string current, string page)
		{
			string nav = page.Replace("\\", "/").ToLower();
			return nav.Equals(current.ToLower());
		}

	}
}

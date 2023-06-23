using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Midtrans.Payment.Webview.Helpers;
using Midtrans.Payment.Webview.Models;
using System.Diagnostics;

namespace Midtrans.Payment.Webview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public IActionResult Index()
        {
			HttpContext.Response.Cookies.Append(HelperClient.COOKIES_API, _configuration.GetValue<string>("APIBaseUrl"),
											new CookieOptions { Expires = System.DateTime.MaxValue });
			return View();
        }

		public IActionResult Login()
		{
			return View();
		}
	}
}
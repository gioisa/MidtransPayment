using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Midtrans.Payment.Webview.Controllers;

namespace Midtrans.Payment.Webview.Areas.AdminZone.Controller
{
	
	public class AdminZoneController : BaseController<AdminZoneController>
	{
		private readonly ILogger<AdminZoneController> _logger;

		public AdminZoneController(ILogger<AdminZoneController> logger)
		{
			_logger = logger;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}

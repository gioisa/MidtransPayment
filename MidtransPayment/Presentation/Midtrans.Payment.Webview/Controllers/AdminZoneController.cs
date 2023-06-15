using Microsoft.AspNetCore.Mvc;

namespace Midtrans.Payment.Webview.Controllers
{
    public class AdminZoneController : Controller
    {
		private readonly ILogger<AdminZoneController> _logger;

		public AdminZoneController(ILogger<AdminZoneController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
        {
            return View("Views/AdminZone/Dashboard/Index.cshtml");
        }
    }
}

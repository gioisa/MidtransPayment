using Microsoft.AspNetCore.Mvc;
using Midtrans.Payment.Webview.Models;
using System.Diagnostics;

namespace Midtrans.Payment.Webview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
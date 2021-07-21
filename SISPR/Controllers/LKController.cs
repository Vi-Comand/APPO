using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISPR.Models;
using System.Diagnostics;

namespace SISPR.Controllers
{
    public class LKController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public LKController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Profile()
        {
            return View();
        }

    }
}
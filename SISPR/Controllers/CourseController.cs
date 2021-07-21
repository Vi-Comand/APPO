using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISPR.Models;
using System.Diagnostics;

namespace SISPR.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CourseController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult AddCourse()
        {
            return View();
        }


    }
}
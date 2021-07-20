﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISPR.Models;
using System.Diagnostics;

namespace SISPR.Controllers
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
            ErrorViewModel model = new ErrorViewModel();
            model.RequestId = "Работай";
            return View("Index", model);
        }

        public IActionResult Profil()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
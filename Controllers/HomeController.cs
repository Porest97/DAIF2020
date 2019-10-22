using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAIF2020.Models;

namespace DAIF2020.Controllers
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

        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Arenas()
        {
            return View();
        }

        public IActionResult Clubs()
        {
            return View();
        }

        public IActionResult Districts()
        {
            return View();
        }

        public IActionResult People()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Economics()
        {
            return View();
        }

        public IActionResult Games()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Associations()
        {
            return View();
        }

        public IActionResult Links()
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

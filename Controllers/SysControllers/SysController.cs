using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DAIF2020.Controllers.SysControllers
{
    public class SysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
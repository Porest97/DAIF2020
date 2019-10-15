using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAIF2020.Data;
using DAIF2020.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DAIF2020.Controllers.SettingsControllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }
                
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
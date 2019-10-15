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
                
        /// <summary>
        /// All of this List LALALALAAA must be moved in to ther own controllers
        /// </summary>
        /// <returns></returns>
        

        public IActionResult ListPersonRoles()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                PersonRoles = _context.PersonRole.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListPersonStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                PersonStatuses = _context.PersonStatus.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListPersonTypes()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                PersonTypes = _context.PersonType.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListGameCategories()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                GameCategories = _context.GameCategory.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListGameStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                GameStatuses = _context.GameStatus.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListGameTypes()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                GameTypes = _context.GameType.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListReceiptCategories()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                ReceiptCategories = _context.ReceiptCategory.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListReceiptStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                ReceiptStatuses = _context.ReceiptStatus.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult ListReceiptTypes()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                ReceiptTypes = _context.ReceiptType.ToList()
            };
            return View(settingsViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
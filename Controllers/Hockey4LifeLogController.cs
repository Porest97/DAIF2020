using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.DataModels;
using DAIF2020.Models.ViewModels;

namespace DAIF2020.Controllers
{
    public class Hockey4LifeLogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Hockey4LifeLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hockey4LifeLog
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3);
            return View(await _context.Hockey4LifeLog.ToListAsync());
        }

        //ListHockey4LifeLogs
        public IActionResult ListHockey4LifeLogs()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2012
        public IActionResult ListHockey4LifeLogs2012()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id < 341)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2013
        public IActionResult ListHockey4LifeLogs2013()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 340).Where(h => h.Id < 706)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2014
        public IActionResult ListHockey4LifeLogs2014()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 705).Where(h => h.Id < 1071)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2015
        public IActionResult ListHockey4LifeLogs2015()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 1070).Where(h => h.Id < 1436)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2016
        public IActionResult ListHockey4LifeLogs2016()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 1435).Where(h => h.Id < 1802)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2017
        public IActionResult ListHockey4LifeLogs2017()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 1801).Where(h => h.Id < 2167)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2018
        public IActionResult ListHockey4LifeLogs2018()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 2166).Where(h => h.Id < 2532)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2019
        public IActionResult ListHockey4LifeLogs2019()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 2531).Where(h => h.Id < 2897)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        //ListHockey4LifeLogs2020
        public IActionResult ListHockey4LifeLogs2020()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3).Where(h => h.Id > 2896).Where(h => h.Id < 3263)
                .ToList()
            };
            return View(hockey4LifeLogsVewModel);
        }

        // GET: Hockey4LifeLog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hockey4LifeLog = await _context.Hockey4LifeLog
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hockey4LifeLog == null)
            {
                return NotFound();
            }

            return View(hockey4LifeLog);
        }

        // GET: Hockey4LifeLog/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber");
            return View();
        }

        // POST: Hockey4LifeLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Events,HockeyDay,DayInLife,Hours,NumberOfGames,GameId,GameId1,GameId2")] Hockey4LifeLog hockey4LifeLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hockey4LifeLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListHockey4LifeLogs));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId2);
            return View(hockey4LifeLog);
        }

        // GET: Hockey4LifeLog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hockey4LifeLog = await _context.Hockey4LifeLog.FindAsync(id);
            if (hockey4LifeLog == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId2);
            return View(hockey4LifeLog);
        }

        // POST: Hockey4LifeLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Events,HockeyDay,DayInLife,Hours,NumberOfGames,GameId,GameId1,GameId2")] Hockey4LifeLog hockey4LifeLog)
        {
            if (id != hockey4LifeLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hockey4LifeLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Hockey4LifeLogExists(hockey4LifeLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListHockey4LifeLogs));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId2);
            return View(hockey4LifeLog);
        }

        // GET: Hockey4LifeLog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hockey4LifeLog = await _context.Hockey4LifeLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hockey4LifeLog == null)
            {
                return NotFound();
            }

            return View(hockey4LifeLog);
        }

        // POST: Hockey4LifeLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hockey4LifeLog = await _context.Hockey4LifeLog.FindAsync(id);
            _context.Hockey4LifeLog.Remove(hockey4LifeLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListHockey4LifeLogs));
        }

        private bool Hockey4LifeLogExists(int id)
        {
            return _context.Hockey4LifeLog.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.DataModels;

namespace DAIF2020.Controllers
{
    public class Hockey4LifeLog1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Hockey4LifeLog1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hockey4LifeLog1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hockey4LifeLog                
                .Include(h => h.Game1)
                .Include(h => h.Game2)
                .Include(h => h.Game3);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hockey4LifeLog1/Details/5
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

        // GET: Hockey4LifeLog1/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber");
            return View();
        }

        // POST: Hockey4LifeLog1/Create
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId2);
            return View(hockey4LifeLog);
        }

        // GET: Hockey4LifeLog1/Edit/5
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

        // POST: Hockey4LifeLog1/Edit/5
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", hockey4LifeLog.GameId2);
            return View(hockey4LifeLog);
        }

        // GET: Hockey4LifeLog1/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Hockey4LifeLog1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hockey4LifeLog = await _context.Hockey4LifeLog.FindAsync(id);
            _context.Hockey4LifeLog.Remove(hockey4LifeLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Hockey4LifeLogExists(int id)
        {
            return _context.Hockey4LifeLog.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.SportsLogs.Models.DataModels;
using DAIF2020.SportsLogs.Models.ViewModels;

namespace DAIF2020.SportsLogs.Controllers
{
    public class SportsLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportsLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SportsLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SportsLog
                .Include(s => s.Person)
                .Include(s => s.Sport);
            return View(await applicationDbContext.ToListAsync());
        }

        //SportsLogs (All)
        public IActionResult ListSportsLogs()
        {
            var sPLViewModel = new SPLViewModel()
            {
                SportLogs = _context.SportsLog
                .Include(s => s.Person)
                .Include(s => s.Sport)
                .ToList()
            };
            return View(sPLViewModel);
        }

        // GET: SportsLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsLog = await _context.SportsLog
                .Include(s => s.Person)
                .Include(s => s.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportsLog == null)
            {
                return NotFound();
            }

            return View(sportsLog);
        }

        // GET: SportsLogs/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName");
            return View();
        }

        // POST: SportsLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,SportId,DateTimeStart,DateTimeEnd,TimeSpent")] SportsLog sportsLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportsLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSportsLogs));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", sportsLog.PersonId);
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName", sportsLog.SportId);
            return View(sportsLog);
        }

        // GET: SportsLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsLog = await _context.SportsLog.FindAsync(id);
            if (sportsLog == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", sportsLog.PersonId);
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName", sportsLog.SportId);
            return View(sportsLog);
        }

        // POST: SportsLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,SportId,DateTimeStart,DateTimeEnd,TimeSpent")] SportsLog sportsLog)
        {
            if (id != sportsLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportsLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportsLogExists(sportsLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSportsLogs));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", sportsLog.PersonId);
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName", sportsLog.SportId);
            return View(sportsLog);
        }

        // GET: SportsLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsLog = await _context.SportsLog
                .Include(s => s.Person)
                .Include(s => s.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportsLog == null)
            {
                return NotFound();
            }

            return View(sportsLog);
        }

        // POST: SportsLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportsLog = await _context.SportsLog.FindAsync(id);
            _context.SportsLog.Remove(sportsLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSportsLogs));
        }

        private bool SportsLogExists(int id)
        {
            return _context.SportsLog.Any(e => e.Id == id);
        }
    }
}

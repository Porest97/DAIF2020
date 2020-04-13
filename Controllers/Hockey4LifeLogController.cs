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
            return View(await _context.Hockey4LifeLog.ToListAsync());
        }

        //ListHockey4LifeLogs
        public IActionResult ListHockey4LifeLogs()
        {
            var hockey4LifeLogsVewModel = new Hockey4LifeLogsViewModel()
            {
                Hockey4LifeLogs = _context.Hockey4LifeLog
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
            return View();
        }

        // POST: Hockey4LifeLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Events,HockeyDay,DayInLife,Hours,NumberOfGames")] Hockey4LifeLog hockey4LifeLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hockey4LifeLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListHockey4LifeLogs));
            }
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
            return View(hockey4LifeLog);
        }

        // POST: Hockey4LifeLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Events,HockeyDay,DayInLife,Hours,NumberOfGames")] Hockey4LifeLog hockey4LifeLog)
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

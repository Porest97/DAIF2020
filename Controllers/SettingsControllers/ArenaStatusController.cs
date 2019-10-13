using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.SettingModels;

namespace DAIF2020.Controllers.SettingsControllers
{
    public class ArenaStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArenaStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArenaStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArenaStatus.ToListAsync());
        }

        // GET: ArenaStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arenaStatus = await _context.ArenaStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arenaStatus == null)
            {
                return NotFound();
            }

            return View(arenaStatus);
        }

        // GET: ArenaStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArenaStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArenaStatusName")] ArenaStatus arenaStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arenaStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arenaStatus);
        }

        // GET: ArenaStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arenaStatus = await _context.ArenaStatus.FindAsync(id);
            if (arenaStatus == null)
            {
                return NotFound();
            }
            return View(arenaStatus);
        }

        // POST: ArenaStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArenaStatusName")] ArenaStatus arenaStatus)
        {
            if (id != arenaStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arenaStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArenaStatusExists(arenaStatus.Id))
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
            return View(arenaStatus);
        }

        // GET: ArenaStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arenaStatus = await _context.ArenaStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arenaStatus == null)
            {
                return NotFound();
            }

            return View(arenaStatus);
        }

        // POST: ArenaStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arenaStatus = await _context.ArenaStatus.FindAsync(id);
            _context.ArenaStatus.Remove(arenaStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArenaStatusExists(int id)
        {
            return _context.ArenaStatus.Any(e => e.Id == id);
        }
    }
}

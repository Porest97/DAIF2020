using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.SettingModels;

namespace DAIF2020.Controllers
{
    public class ClubStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClubStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClubStatus.ToListAsync());
        }

        // GET: ClubStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubStatus = await _context.ClubStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubStatus == null)
            {
                return NotFound();
            }

            return View(clubStatus);
        }

        // GET: ClubStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClubStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClubStatusName")] ClubStatus clubStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clubStatus);
        }

        // GET: ClubStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubStatus = await _context.ClubStatus.FindAsync(id);
            if (clubStatus == null)
            {
                return NotFound();
            }
            return View(clubStatus);
        }

        // POST: ClubStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClubStatusName")] ClubStatus clubStatus)
        {
            if (id != clubStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubStatusExists(clubStatus.Id))
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
            return View(clubStatus);
        }

        // GET: ClubStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubStatus = await _context.ClubStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubStatus == null)
            {
                return NotFound();
            }

            return View(clubStatus);
        }

        // POST: ClubStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubStatus = await _context.ClubStatus.FindAsync(id);
            _context.ClubStatus.Remove(clubStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubStatusExists(int id)
        {
            return _context.ClubStatus.Any(e => e.Id == id);
        }
    }
}

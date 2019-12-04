using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.TSM.Models.DataModels;

namespace DAIF2020.TSM.Controllers
{
    public class TSMGameStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TSMGameStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TSMGameStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TSMGameStatus.ToListAsync());
        }

        // GET: TSMGameStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSMGameStatus = await _context.TSMGameStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tSMGameStatus == null)
            {
                return NotFound();
            }

            return View(tSMGameStatus);
        }

        // GET: TSMGameStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TSMGameStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TSMGameStatusName")] TSMGameStatus tSMGameStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tSMGameStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tSMGameStatus);
        }

        // GET: TSMGameStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSMGameStatus = await _context.TSMGameStatus.FindAsync(id);
            if (tSMGameStatus == null)
            {
                return NotFound();
            }
            return View(tSMGameStatus);
        }

        // POST: TSMGameStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TSMGameStatusName")] TSMGameStatus tSMGameStatus)
        {
            if (id != tSMGameStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tSMGameStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSMGameStatusExists(tSMGameStatus.Id))
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
            return View(tSMGameStatus);
        }

        // GET: TSMGameStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSMGameStatus = await _context.TSMGameStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tSMGameStatus == null)
            {
                return NotFound();
            }

            return View(tSMGameStatus);
        }

        // POST: TSMGameStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSMGameStatus = await _context.TSMGameStatus.FindAsync(id);
            _context.TSMGameStatus.Remove(tSMGameStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TSMGameStatusExists(int id)
        {
            return _context.TSMGameStatus.Any(e => e.Id == id);
        }
    }
}

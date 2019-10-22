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
    public class TournamentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TournamentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TournamentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TournamentType.ToListAsync());
        }

        // GET: TournamentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournamentType = await _context.TournamentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tournamentType == null)
            {
                return NotFound();
            }

            return View(tournamentType);
        }

        // GET: TournamentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TournamentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TournamentTypeName")] TournamentType tournamentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournamentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tournamentType);
        }

        // GET: TournamentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournamentType = await _context.TournamentType.FindAsync(id);
            if (tournamentType == null)
            {
                return NotFound();
            }
            return View(tournamentType);
        }

        // POST: TournamentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TournamentTypeName")] TournamentType tournamentType)
        {
            if (id != tournamentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournamentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentTypeExists(tournamentType.Id))
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
            return View(tournamentType);
        }

        // GET: TournamentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournamentType = await _context.TournamentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tournamentType == null)
            {
                return NotFound();
            }

            return View(tournamentType);
        }

        // POST: TournamentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournamentType = await _context.TournamentType.FindAsync(id);
            _context.TournamentType.Remove(tournamentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournamentTypeExists(int id)
        {
            return _context.TournamentType.Any(e => e.Id == id);
        }
    }
}

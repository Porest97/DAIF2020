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
    public class GameStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameStatus.ToListAsync());
        }

        // GET: GameStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStatus = await _context.GameStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameStatus == null)
            {
                return NotFound();
            }

            return View(gameStatus);
        }

        // GET: GameStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameStatusName")] GameStatus gameStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameStatus);
        }

        // GET: GameStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStatus = await _context.GameStatus.FindAsync(id);
            if (gameStatus == null)
            {
                return NotFound();
            }
            return View(gameStatus);
        }

        // POST: GameStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameStatusName")] GameStatus gameStatus)
        {
            if (id != gameStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameStatusExists(gameStatus.Id))
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
            return View(gameStatus);
        }

        // GET: GameStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStatus = await _context.GameStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameStatus == null)
            {
                return NotFound();
            }

            return View(gameStatus);
        }

        // POST: GameStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameStatus = await _context.GameStatus.FindAsync(id);
            _context.GameStatus.Remove(gameStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameStatusExists(int id)
        {
            return _context.GameStatus.Any(e => e.Id == id);
        }
    }
}

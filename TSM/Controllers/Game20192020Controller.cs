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
    public class Game20192020Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Game20192020Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Game20192020
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Game20192020
                .Include(g => g.TSMGameStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Game20192020/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game20192020 = await _context.Game20192020
                .Include(g => g.TSMGameStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game20192020 == null)
            {
                return NotFound();
            }

            return View(game20192020);
        }

        // GET: Game20192020/Create
        public IActionResult Create()
        {
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName");
            return View();
        }

        // POST: Game20192020/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TSMGameStatusId,GameDateTime,GameLength,WeekDay,GameNumber,Round,HomeTeam,AwayTeam,Arena,Series,HD1,HD2,LD1,LD2")] Game20192020 game20192020)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game20192020);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName", game20192020.TSMGameStatusId);
            return View(game20192020);
        }

        // GET: Game20192020/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game20192020 = await _context.Game20192020.FindAsync(id);
            if (game20192020 == null)
            {
                return NotFound();
            }
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName", game20192020.TSMGameStatusId);
            return View(game20192020);
        }

        // POST: Game20192020/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TSMGameStatusId,GameDateTime,GameLength,WeekDay,GameNumber,Round,HomeTeam,AwayTeam,Arena,Series,HD1,HD2,LD1,LD2")] Game20192020 game20192020)
        {
            if (id != game20192020.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game20192020);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Game20192020Exists(game20192020.Id))
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
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName", game20192020.TSMGameStatusId);
            return View(game20192020);
        }

        // GET: Game20192020/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game20192020 = await _context.Game20192020
                .Include(g => g.TSMGameStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game20192020 == null)
            {
                return NotFound();
            }

            return View(game20192020);
        }

        // POST: Game20192020/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game20192020 = await _context.Game20192020.FindAsync(id);
            _context.Game20192020.Remove(game20192020);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Game20192020Exists(int id)
        {
            return _context.Game20192020.Any(e => e.Id == id);
        }
    }
}

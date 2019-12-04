using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.TSM.Models.DataModels;
using DAIF2020.TSM.Models.ViewModels;

namespace DAIF2020.TSM.Controllers
{
    public class TSMGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TSMGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TSMGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TSMGame
                .Include(t => t.TSMGameStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        //TSMGame (Scheduled)
        public IActionResult ListTSMGames()
        {
            var tSMGamesViewModel = new TSMGamesViewModel()
            {
                TSMGames = _context.TSMGame
                .Include(t => t.TSMGameStatus)
                .Include(g => g.TSMGameStatus).Where(g => g.TSMGameStatusId == 1)
                .ToList()
            };
            return View(tSMGamesViewModel);
        }

        // GET: TSMGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSMGame = await _context.TSMGame
                .Include(t => t.TSMGameStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tSMGame == null)
            {
                return NotFound();
            }

            return View(tSMGame);
        }

        // GET: TSMGames/Create
        public IActionResult Create()
        {
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName");
            return View();
        }

        // POST: TSMGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameDateTime,WeekDay,GameNumber,Round,HomeTeam,AwayTeam,Arena,Series,HD1,HD2,LD1,LD2,Supervisor,DateChanged,ChangedBy,TSMGameStatusId")] TSMGame tSMGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tSMGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTSMGames));
            }
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName", tSMGame.TSMGameStatusId);
            return View(tSMGame);
        }

        // GET: TSMGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSMGame = await _context.TSMGame.FindAsync(id);
            if (tSMGame == null)
            {
                return NotFound();
            }
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName", tSMGame.TSMGameStatusId);
            return View(tSMGame);
        }

        // POST: TSMGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameDateTime,WeekDay,GameNumber,Round,HomeTeam,AwayTeam,Arena,Series,HD1,HD2,LD1,LD2,Supervisor,DateChanged,ChangedBy,TSMGameStatusId")] TSMGame tSMGame)
        {
            if (id != tSMGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tSMGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSMGameExists(tSMGame.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTSMGames));
            }
            ViewData["TSMGameStatusId"] = new SelectList(_context.TSMGameStatus, "Id", "TSMGameStatusName", tSMGame.TSMGameStatusId);
            return View(tSMGame);
        }

        // GET: TSMGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSMGame = await _context.TSMGame
                .Include(t => t.TSMGameStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tSMGame == null)
            {
                return NotFound();
            }

            return View(tSMGame);
        }

        // POST: TSMGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSMGame = await _context.TSMGame.FindAsync(id);
            _context.TSMGame.Remove(tSMGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListTSMGames));
        }

        private bool TSMGameExists(int id)
        {
            return _context.TSMGame.Any(e => e.Id == id);
        }
    }
}

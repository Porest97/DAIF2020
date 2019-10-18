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
    public class PoolGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoolGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoolGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PoolGame
                .Include(p => p.Arena)
                .Include(p => p.HostingTeam)
                .Include(p => p.ZoneGame1)
                .Include(p => p.ZoneGame2)
                .Include(p => p.ZoneGame3);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListPoolGames()
        {
            var poolGamesViewModel = new PoolGamesViewModel()
            {
                PoolGames = _context.PoolGame
                .Include(p => p.Arena)
                .Include(p => p.HostingTeam)
                .Include(p => p.ZoneGame1)
                .Include(p => p.ZoneGame2)
                .Include(p => p.ZoneGame3)
                .ToList()
            };
            return View(poolGamesViewModel);
        }

        // GET: PoolGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGame = await _context.PoolGame
                .Include(p => p.Arena)
                .Include(p => p.HostingTeam)
                .Include(p => p.ZoneGame1)
                .Include(p => p.ZoneGame2)
                .Include(p => p.ZoneGame3)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGame == null)
            {
                return NotFound();
            }

            return View(poolGame);
        }

        // GET: PoolGames/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName");
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName");
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName");
            return View();
        }

        // POST: PoolGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoolGameDateTime,PoolGameName,ArenaId,ClubId,ZoneGameId,ZoneGameId1,ZoneGameId2")] PoolGame poolGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poolGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListPoolGames));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGame.ArenaId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", poolGame.ClubId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId);
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId1);
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId2);
            return View(poolGame);
        }

        // GET: PoolGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGame = await _context.PoolGame.FindAsync(id);
            if (poolGame == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGame.ArenaId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", poolGame.ClubId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId);
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId1);
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId2);
            return View(poolGame);
        }

        // POST: PoolGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoolGameDateTime,PoolGameName,ArenaId,ClubId,ZoneGameId,ZoneGameId1,ZoneGameId2")] PoolGame poolGame)
        {
            if (id != poolGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poolGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoolGameExists(poolGame.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListPoolGames));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGame.ArenaId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", poolGame.ClubId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId);
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId1);
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", poolGame.ZoneGameId2);
            return View(poolGame);
        }

        // GET: PoolGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGame = await _context.PoolGame
                .Include(p => p.Arena)
                .Include(p => p.HostingTeam)
                .Include(p => p.ZoneGame1)
                .Include(p => p.ZoneGame2)
                .Include(p => p.ZoneGame3)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGame == null)
            {
                return NotFound();
            }

            return View(poolGame);
        }

        // POST: PoolGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poolGame = await _context.PoolGame.FindAsync(id);
            _context.PoolGame.Remove(poolGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListPoolGames));
        }

        private bool PoolGameExists(int id)
        {
            return _context.PoolGame.Any(e => e.Id == id);
        }
    }
}

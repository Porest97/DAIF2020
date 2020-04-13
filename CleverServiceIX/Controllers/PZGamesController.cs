using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.CleverServiceIX.DataModels;
using DAIF2020.Data;

namespace DAIF2020.CleverServiceIX.Controllers
{
    public class PZGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PZGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PZGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PZGame.Include(p => p.Arena).Include(p => p.GameCategory).Include(p => p.GameStatus).Include(p => p.GameType).Include(p => p.HostingClub).Include(p => p.ZoneGame1).Include(p => p.ZoneGame10).Include(p => p.ZoneGame11).Include(p => p.ZoneGame12).Include(p => p.ZoneGame2).Include(p => p.ZoneGame3).Include(p => p.ZoneGame4).Include(p => p.ZoneGame5).Include(p => p.ZoneGame6).Include(p => p.ZoneGame7).Include(p => p.ZoneGame8).Include(p => p.ZoneGame9);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PZGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZGame = await _context.PZGame
                .Include(p => p.Arena)
                .Include(p => p.GameCategory)
                .Include(p => p.GameStatus)
                .Include(p => p.GameType)
                .Include(p => p.HostingClub)
                .Include(p => p.ZoneGame1)
                .Include(p => p.ZoneGame10)
                .Include(p => p.ZoneGame11)
                .Include(p => p.ZoneGame12)
                .Include(p => p.ZoneGame2)
                .Include(p => p.ZoneGame3)
                .Include(p => p.ZoneGame4)
                .Include(p => p.ZoneGame5)
                .Include(p => p.ZoneGame6)
                .Include(p => p.ZoneGame7)
                .Include(p => p.ZoneGame8)
                .Include(p => p.ZoneGame9)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pZGame == null)
            {
                return NotFound();
            }

            return View(pZGame);
        }

        // GET: PZGames/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "Id");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "Id");
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "Id");
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "Id");
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id");
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId9"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId10"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId11"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId3"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId4"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId5"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId6"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId7"] = new SelectList(_context.ZoneGame, "Id", "Id");
            ViewData["ZoneGameId8"] = new SelectList(_context.ZoneGame, "Id", "Id");
            return View();
        }

        // POST: PZGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PZGameName,GameCategoryId,GameStatusId,GameTypeId,ZoneGameId,ZoneGameId1,ZoneGameId2,ZoneGameId3,ZoneGameId4,ZoneGameId5,ZoneGameId6,ZoneGameId7,ZoneGameId8,ZoneGameId9,ZoneGameId10,ZoneGameId11,ClubId,ArenaId")] PZGame pZGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pZGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "Id", pZGame.ArenaId);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "Id", pZGame.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "Id", pZGame.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "Id", pZGame.GameTypeId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id", pZGame.ClubId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId);
            ViewData["ZoneGameId9"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId9);
            ViewData["ZoneGameId10"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId10);
            ViewData["ZoneGameId11"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId11);
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId1);
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId2);
            ViewData["ZoneGameId3"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId3);
            ViewData["ZoneGameId4"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId4);
            ViewData["ZoneGameId5"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId5);
            ViewData["ZoneGameId6"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId6);
            ViewData["ZoneGameId7"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId7);
            ViewData["ZoneGameId8"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId8);
            return View(pZGame);
        }

        // GET: PZGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZGame = await _context.PZGame.FindAsync(id);
            if (pZGame == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "Id", pZGame.ArenaId);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "Id", pZGame.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "Id", pZGame.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "Id", pZGame.GameTypeId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id", pZGame.ClubId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId);
            ViewData["ZoneGameId9"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId9);
            ViewData["ZoneGameId10"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId10);
            ViewData["ZoneGameId11"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId11);
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId1);
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId2);
            ViewData["ZoneGameId3"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId3);
            ViewData["ZoneGameId4"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId4);
            ViewData["ZoneGameId5"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId5);
            ViewData["ZoneGameId6"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId6);
            ViewData["ZoneGameId7"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId7);
            ViewData["ZoneGameId8"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId8);
            return View(pZGame);
        }

        // POST: PZGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PZGameName,GameCategoryId,GameStatusId,GameTypeId,ZoneGameId,ZoneGameId1,ZoneGameId2,ZoneGameId3,ZoneGameId4,ZoneGameId5,ZoneGameId6,ZoneGameId7,ZoneGameId8,ZoneGameId9,ZoneGameId10,ZoneGameId11,ClubId,ArenaId")] PZGame pZGame)
        {
            if (id != pZGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pZGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PZGameExists(pZGame.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "Id", pZGame.ArenaId);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "Id", pZGame.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "Id", pZGame.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "Id", pZGame.GameTypeId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id", pZGame.ClubId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId);
            ViewData["ZoneGameId9"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId9);
            ViewData["ZoneGameId10"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId10);
            ViewData["ZoneGameId11"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId11);
            ViewData["ZoneGameId1"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId1);
            ViewData["ZoneGameId2"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId2);
            ViewData["ZoneGameId3"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId3);
            ViewData["ZoneGameId4"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId4);
            ViewData["ZoneGameId5"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId5);
            ViewData["ZoneGameId6"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId6);
            ViewData["ZoneGameId7"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId7);
            ViewData["ZoneGameId8"] = new SelectList(_context.ZoneGame, "Id", "Id", pZGame.ZoneGameId8);
            return View(pZGame);
        }

        // GET: PZGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZGame = await _context.PZGame
                .Include(p => p.Arena)
                .Include(p => p.GameCategory)
                .Include(p => p.GameStatus)
                .Include(p => p.GameType)
                .Include(p => p.HostingClub)
                .Include(p => p.ZoneGame1)
                .Include(p => p.ZoneGame10)
                .Include(p => p.ZoneGame11)
                .Include(p => p.ZoneGame12)
                .Include(p => p.ZoneGame2)
                .Include(p => p.ZoneGame3)
                .Include(p => p.ZoneGame4)
                .Include(p => p.ZoneGame5)
                .Include(p => p.ZoneGame6)
                .Include(p => p.ZoneGame7)
                .Include(p => p.ZoneGame8)
                .Include(p => p.ZoneGame9)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pZGame == null)
            {
                return NotFound();
            }

            return View(pZGame);
        }

        // POST: PZGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pZGame = await _context.PZGame.FindAsync(id);
            _context.PZGame.Remove(pZGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PZGameExists(int id)
        {
            return _context.PZGame.Any(e => e.Id == id);
        }
    }
}

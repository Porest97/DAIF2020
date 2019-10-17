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
    public class ZoneGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZoneGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZoneGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ZoneGame
                .Include(z => z.Arena)
                .Include(z => z.AwayTeam1)
                .Include(z => z.AwayTeam2)
                .Include(z => z.GameCategory)
                .Include(z => z.GameStatus)
                .Include(z => z.GameType)
                .Include(z => z.HomeTeam1)
                .Include(z => z.HomeTeam2)
                .Include(z => z.Supervisor)
                .Include(z => z.UDZ1)
                .Include(z => z.UDZ2)
                .Include(z => z.Zone1)
                .Include(z => z.Zone2);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListZoneGames()
        {
            var zoneGamesViewModel = new ZoneGamesViewModel()
            {
                ZoneGames = _context.ZoneGame
                .Include(z => z.Arena)
                .Include(z => z.AwayTeam1)
                .Include(z => z.AwayTeam2)
                .Include(z => z.GameCategory)
                .Include(z => z.GameStatus)
                .Include(z => z.GameType)
                .Include(z => z.HomeTeam1)
                .Include(z => z.HomeTeam2)
                .Include(z => z.Supervisor)
                .Include(z => z.UDZ1)
                .Include(z => z.UDZ2)
                .Include(z => z.Zone1)
                .Include(z => z.Zone2)
                .ToList()
            };
            return View(zoneGamesViewModel);
        }

        // GET: ZoneGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoneGame = await _context.ZoneGame
                .Include(z => z.Arena)
                .Include(z => z.AwayTeam1)
                .Include(z => z.AwayTeam2)
                .Include(z => z.GameCategory)
                .Include(z => z.GameStatus)
                .Include(z => z.GameType)
                .Include(z => z.HomeTeam1)
                .Include(z => z.HomeTeam2)
                .Include(z => z.Supervisor)
                .Include(z => z.UDZ1)
                .Include(z => z.UDZ2)
                .Include(z => z.Zone1)
                .Include(z => z.Zone2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoneGame == null)
            {
                return NotFound();
            }

            return View(zoneGame);
        }

        // GET: ZoneGames/Create
        public IActionResult Create()
        {
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["ClubId3"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName");
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName");
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName");
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["ClubId2"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "ZoneName");
            ViewData["ZoneId1"] = new SelectList(_context.Zone, "Id", "ZoneName");
            return View();
        }

        // POST: ZoneGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArenaId,GameCategoryId,GameStatusId,GameTypeId,ZoneId,TSMNumberZone1,ClubId,ClubId1,PersonId,ZoneId1,TSMNumberZone2,ClubId2,ClubId3,PersonId1,PersonId2,ZoneGameDateTime,ZoneGameName")] ZoneGame zoneGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zoneGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListZoneGames));
            }
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaName", zoneGame.ArenaId);
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId1);
            ViewData["ClubId3"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId3);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", zoneGame.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", zoneGame.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName", zoneGame.GameTypeId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId);
            ViewData["ClubId2"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId2);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId2);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId1);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "ZoneName", zoneGame.ZoneId);
            ViewData["ZoneId1"] = new SelectList(_context.Zone, "Id", "ZoneName", zoneGame.ZoneId1);
            return View(zoneGame);
        }

        // GET: ZoneGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoneGame = await _context.ZoneGame.FindAsync(id);
            if (zoneGame == null)
            {
                return NotFound();
            }
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaName", zoneGame.ArenaId);
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId1);
            ViewData["ClubId3"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId3);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", zoneGame.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", zoneGame.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName", zoneGame.GameTypeId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId);
            ViewData["ClubId2"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId2);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId2);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId1);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "ZoneName", zoneGame.ZoneId);
            ViewData["ZoneId1"] = new SelectList(_context.Zone, "Id", "ZoneName", zoneGame.ZoneId1);
            return View(zoneGame);
        }

        // POST: ZoneGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArenaId,GameCategoryId,GameStatusId,GameTypeId,ZoneId,TSMNumberZone1,ClubId,ClubId1,PersonId,ZoneId1,TSMNumberZone2,ClubId2,ClubId3,PersonId1,PersonId2,ZoneGameDateTime,ZoneGameName")] ZoneGame zoneGame)
        {
            if (id != zoneGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zoneGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoneGameExists(zoneGame.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListZoneGames));
            }
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaName", zoneGame.ArenaId);
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId1);
            ViewData["ClubId3"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId3);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", zoneGame.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", zoneGame.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName", zoneGame.GameTypeId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId);
            ViewData["ClubId2"] = new SelectList(_context.Club, "Id", "ClubName", zoneGame.ClubId2);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId2);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", zoneGame.PersonId1);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "ZoneName", zoneGame.ZoneId);
            ViewData["ZoneId1"] = new SelectList(_context.Zone, "Id", "ZoneName", zoneGame.ZoneId1);
            return View(zoneGame);
        }

        // GET: ZoneGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoneGame = await _context.ZoneGame
                .Include(z => z.Arena)
                .Include(z => z.AwayTeam1)
                .Include(z => z.AwayTeam2)
                .Include(z => z.GameCategory)
                .Include(z => z.GameStatus)
                .Include(z => z.GameType)
                .Include(z => z.HomeTeam1)
                .Include(z => z.HomeTeam2)
                .Include(z => z.Supervisor)
                .Include(z => z.UDZ1)
                .Include(z => z.UDZ2)
                .Include(z => z.Zone1)
                .Include(z => z.Zone2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoneGame == null)
            {
                return NotFound();
            }

            return View(zoneGame);
        }

        // POST: ZoneGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zoneGame = await _context.ZoneGame.FindAsync(id);
            _context.ZoneGame.Remove(zoneGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListZoneGames));
        }

        private bool ZoneGameExists(int id)
        {
            return _context.ZoneGame.Any(e => e.Id == id);
        }
    }
}

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
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)
                .Include(g => g.GameStatus)
                .Include(g => g.GameType)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2);
            return View(await applicationDbContext.ToListAsync());
        }
        //Game (Scheduled)
        public IActionResult ListGames()
        {
            var gamesViewModel = new GamesViewModel()
            {
                Games = _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)                
                .Include(g => g.GameType)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .Include(g => g.GameStatus).Where(g=> g.GameStatusId == 1)
                .ToList()
            };
            return View(gamesViewModel);
        }
        //Game (Final)
        public IActionResult ListGamesFinal()
        {
            var gamesViewModel = new GamesViewModel()
            {
                Games = _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)                
                .Include(g => g.GameType)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .Include(g => g.GameStatus).Where(g=> g.GameStatusId == 3)
                .ToList()
            };
            return View(gamesViewModel);
        }
        //Game (Archived)
        public IActionResult ListGamesArchived()
        {
            var gamesViewModel = new GamesViewModel()
            {
                Games = _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)                
                .Include(g => g.GameType)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .Include(g => g.GameStatus).Where(g=> g.GameStatusId == 4)
                .ToList()
            };
            return View(gamesViewModel);
        }

        //Game (PZ-Game)
        public IActionResult ListGamesPZ()
        {
            var gamesViewModel = new GamesViewModel()
            {
                Games = _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)
                .Include(g => g.GameType)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .Include(g => g.GameStatus).Where(g => g.GameStatusId == 5)
                .ToList()
            };
            return View(gamesViewModel);
        }

        //Game (Cup games)
        public IActionResult ListCupGames()
        {
            var gamesViewModel = new GamesViewModel()
            {
                Games = _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)
                .Include(g => g.GameStatus)                
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .Include(g => g.GameType).Where(g => g.GameTypeId == 5)
                .ToList()
            };
            return View(gamesViewModel);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)
                .Include(g => g.GameStatus)
                .Include(g => g.GameType)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName");
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName");
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameDateTime,GameNumber,TSMNumber,GameCategoryId,GameStatusId,GameTypeId,ArenaId,ClubId,ClubId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListGames));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", game.ArenaId);
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", game.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", game.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName", game.GameTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            return View(game);
        }

        // GET: Games/CreateCupGame
        public IActionResult CreateCupGame()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName");
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName");
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: Games/CreateCupGame
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCupGame([Bind("Id,GameDateTime,GameNumber,TSMNumber,GameCategoryId,GameStatusId,GameTypeId,ArenaId,ClubId,ClubId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListCupGames));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", game.ArenaId);
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", game.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", game.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName", game.GameTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            return View(game);
        }


        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", game.ArenaId);
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", game.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", game.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName", game.GameTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameDateTime,GameNumber,TSMNumber,GameCategoryId,GameStatusId,GameTypeId,ArenaId,ClubId,ClubId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListGames));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", game.ArenaId);
            ViewData["ClubId1"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", game.GameCategoryId);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", game.GameStatusId);
            ViewData["GameTypeId"] = new SelectList(_context.GameType, "Id", "GameTypeName", game.GameTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", game.ClubId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)
                .Include(g => g.GameStatus)
                .Include(g => g.GameType)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListGames));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}

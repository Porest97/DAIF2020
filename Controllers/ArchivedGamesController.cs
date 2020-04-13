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
    public class ArchivedGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArchivedGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArchivedGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ArchivedGame
                .Include(a => a.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        //List ArchivedGames (All)
        public IActionResult ListArchivedGames()
        {
            var arcivedGamesViewModel = new ArchivedGamesViewModel()
            {
                ArchivedGames = _context.ArchivedGame
                 .Include(a => a.Person)
                .ToList()
            };
            return View(arcivedGamesViewModel);
        }

        // GET: ArchivedGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivedGame = await _context.ArchivedGame
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archivedGame == null)
            {
                return NotFound();
            }

            return View(archivedGame);
        }

        // GET: ArchivedGames/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: ArchivedGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,GameNumber,GameCetegory,GameStatus,GameType,Arena,HomeTeam,AwayTeam,Score,HD1,HD2,LD1,LD2,ParticipatedTime,PersonId")] ArchivedGame archivedGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archivedGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListArchivedGames));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", archivedGame.PersonId);
            return View(archivedGame);
        }

        // GET: ArchivedGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivedGame = await _context.ArchivedGame.FindAsync(id);
            if (archivedGame == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", archivedGame.PersonId);
            return View(archivedGame);
        }

        // POST: ArchivedGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,GameNumber,GameCetegory,GameStatus,GameType,Arena,HomeTeam,AwayTeam,Score,HD1,HD2,LD1,LD2,ParticipatedTime,PersonId")] ArchivedGame archivedGame)
        {
            if (id != archivedGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archivedGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchivedGameExists(archivedGame.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListArchivedGames));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", archivedGame.PersonId);
            return View(archivedGame);
        }

        // GET: ArchivedGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivedGame = await _context.ArchivedGame
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archivedGame == null)
            {
                return NotFound();
            }

            return View(archivedGame);
        }

        // POST: ArchivedGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archivedGame = await _context.ArchivedGame.FindAsync(id);
            _context.ArchivedGame.Remove(archivedGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListArchivedGames));
        }

        private bool ArchivedGameExists(int id)
        {
            return _context.ArchivedGame.Any(e => e.Id == id);
        }
    }
}

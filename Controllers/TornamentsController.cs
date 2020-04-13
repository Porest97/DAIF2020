using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;
using DAIF2020.Models.ViewModels;

namespace DAIF2020.Controllers
{
    public class TornamentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TornamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tornaments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tornament
                .Include(t => t.Game1)
                .Include(t => t.Game1.Arena)
                .Include(t => t.Game10)
                .Include(t => t.Game11)
                .Include(t => t.Game12)
                .Include(t => t.Game13)
                .Include(t => t.Game14)
                .Include(t => t.Game15)
                .Include(t => t.Game2)
                .Include(t => t.Game3)
                .Include(t => t.Game4)
                .Include(t => t.Game5)
                .Include(t => t.Game6)
                .Include(t => t.Game7)
                .Include(t => t.Game8)
                .Include(t => t.Game9)
                .Include(t => t.TournamentType);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult ListTournaments()
        {
            var tournamentsViewModel = new TournamentsViewModel()
            {
                Tournaments = _context.Tornament
                .Include(t => t.Game1)
                .Include(t => t.Game1.Arena)
                .Include(t => t.Game10)
                .Include(t => t.Game11)
                .Include(t => t.Game12)
                .Include(t => t.Game13)
                .Include(t => t.Game14)
                .Include(t => t.Game15)
                .Include(t => t.Game2)
                .Include(t => t.Game3)
                .Include(t => t.Game4)
                .Include(t => t.Game5)
                .Include(t => t.Game6)
                .Include(t => t.Game7)
                .Include(t => t.Game8)
                .Include(t => t.Game9)
                .Include(t => t.TournamentType)
                .ToList()
            };
            return View(tournamentsViewModel);
        }

        // GET: Tournament Details !
        public async Task<IActionResult> TournamentDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tornament = await _context.Tornament
                .Include(t => t.Game1)
                .Include(t => t.Game1.Arena)
                .Include(t => t.Game1.GameCategory)
                .Include(t => t.Game1.HomeTeam)
                .Include(t => t.Game1.AwayTeam)
                .Include(t => t.Game1.HD1)
                .Include(t => t.Game1.HD2)
                .Include(t => t.Game2)
                .Include(t => t.Game2.HomeTeam)
                .Include(t => t.Game2.AwayTeam)
                .Include(t => t.Game2.HD1)
                .Include(t => t.Game2.HD2)
                .Include(t => t.Game3)
                .Include(t => t.Game3.HomeTeam)
                .Include(t => t.Game3.AwayTeam)
                .Include(t => t.Game3.HD1)
                .Include(t => t.Game3.HD2)
                .Include(t => t.Game4)
                .Include(t => t.Game4.HomeTeam)
                .Include(t => t.Game4.AwayTeam)
                .Include(t => t.Game4.HD1)
                .Include(t => t.Game4.HD2)
                .Include(t => t.Game5)
                .Include(t => t.Game5.HomeTeam)
                .Include(t => t.Game5.AwayTeam)
                .Include(t => t.Game5.HD1)
                .Include(t => t.Game5.HD2)
                .Include(t => t.Game6)
                .Include(t => t.Game6.HomeTeam)
                .Include(t => t.Game6.AwayTeam)
                .Include(t => t.Game6.HD1)
                .Include(t => t.Game6.HD2)
                .Include(t => t.Game7)
                .Include(t => t.Game7.HomeTeam)
                .Include(t => t.Game7.AwayTeam)
                .Include(t => t.Game7.HD1)
                .Include(t => t.Game7.HD2)
                .Include(t => t.Game8)                
                .Include(t => t.Game8.HomeTeam)
                .Include(t => t.Game8.AwayTeam)
                .Include(t => t.Game8.HD1)
                .Include(t => t.Game8.HD2)
                .Include(t => t.Game9)
                .Include(t => t.Game9.HomeTeam)
                .Include(t => t.Game9.AwayTeam)
                .Include(t => t.Game9.HD1)
                .Include(t => t.Game9.HD2)
                .Include(t => t.Game10)
                .Include(t => t.Game10.HomeTeam)
                .Include(t => t.Game10.AwayTeam)
                .Include(t => t.Game10.HD1)
                .Include(t => t.Game10.HD2)
                .Include(t => t.Game11)
                .Include(t => t.Game11.HomeTeam)
                .Include(t => t.Game11.AwayTeam)
                .Include(t => t.Game11.HD1)
                .Include(t => t.Game11.HD2)
                .Include(t => t.Game11.LD1)
                .Include(t => t.Game11.LD2)
                .Include(t => t.Game12)
                .Include(t => t.Game12.HomeTeam)
                .Include(t => t.Game12.AwayTeam)
                .Include(t => t.Game12.HD1)
                .Include(t => t.Game12.HD2)
                .Include(t => t.Game12.LD1)
                .Include(t => t.Game12.LD2)
                .Include(t => t.Game13)
                .Include(t => t.Game13.HomeTeam)
                .Include(t => t.Game13.AwayTeam)
                .Include(t => t.Game13.HD1)
                .Include(t => t.Game13.HD2)
                .Include(t => t.Game14)
                .Include(t => t.Game14.HomeTeam)
                .Include(t => t.Game14.AwayTeam)
                .Include(t => t.Game14.HD1)
                .Include(t => t.Game14.HD2)
                .Include(t => t.Game15)
                .Include(t => t.Game15.HomeTeam)
                .Include(t => t.Game15.AwayTeam)
                .Include(t => t.Game15.HD1)
                .Include(t => t.Game15.HD2)
                .Include(t => t.TournamentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tornament == null)
            {
                return NotFound();
            }

            return View(tornament);
        }

        // GET: Tornaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tornament = await _context.Tornament
                .Include(t => t.Game1)
                .Include(t => t.Game1.Arena)
                .Include(t => t.Game10)
                .Include(t => t.Game11)
                .Include(t => t.Game12)
                .Include(t => t.Game13)
                .Include(t => t.Game14)
                .Include(t => t.Game15)
                .Include(t => t.Game2)
                .Include(t => t.Game3)
                .Include(t => t.Game4)
                .Include(t => t.Game5)
                .Include(t => t.Game6)
                .Include(t => t.Game7)
                .Include(t => t.Game8)
                .Include(t => t.Game9)
                .Include(t => t.TournamentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tornament == null)
            {
                return NotFound();
            }

            return View(tornament);
        }

        // GET: Tornaments/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId9"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId10"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId11"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId12"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId13"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId14"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId3"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId4"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId5"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId6"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId7"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["GameId8"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["TournamentTypeId"] = new SelectList(_context.Set<TournamentType>(), "Id", "TournamentTypeName");
            return View();
        }

        // POST: Tornaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TournamentName,TournamentDateTime,TournamentTypeId,GameId,GameId1,GameId2,GameId3,GameId4,GameId5,GameId6,GameId7,GameId8,GameId9,GameId10,GameId11,GameId12,GameId13,GameId14")] Tornament tornament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tornament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTournaments));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId);
            ViewData["GameId9"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId9);
            ViewData["GameId10"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId10);
            ViewData["GameId11"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId11);
            ViewData["GameId12"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId12);
            ViewData["GameId13"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId13);
            ViewData["GameId14"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId14);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId2);
            ViewData["GameId3"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId3);
            ViewData["GameId4"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId4);
            ViewData["GameId5"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId5);
            ViewData["GameId6"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId6);
            ViewData["GameId7"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId7);
            ViewData["GameId8"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId8);
            ViewData["TournamentTypeId"] = new SelectList(_context.Set<TournamentType>(), "Id", "TournamentTypeName", tornament.TournamentTypeId);
            return View(tornament);
        }

        // GET: Tornaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tornament = await _context.Tornament.FindAsync(id);
            if (tornament == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId);
            ViewData["GameId9"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId9);
            ViewData["GameId10"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId10);
            ViewData["GameId11"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId11);
            ViewData["GameId12"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId12);
            ViewData["GameId13"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId13);
            ViewData["GameId14"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId14);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId2);
            ViewData["GameId3"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId3);
            ViewData["GameId4"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId4);
            ViewData["GameId5"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId5);
            ViewData["GameId6"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId6);
            ViewData["GameId7"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId7);
            ViewData["GameId8"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId8);
            ViewData["TournamentTypeId"] = new SelectList(_context.Set<TournamentType>(), "Id", "TournamentTypeName", tornament.TournamentTypeId);
            return View(tornament);
        }

        // POST: Tornaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TournamentName,TournamentDateTime,TournamentTypeId,GameId,GameId1,GameId2,GameId3,GameId4,GameId5,GameId6,GameId7,GameId8,GameId9,GameId10,GameId11,GameId12,GameId13,GameId14")] Tornament tornament)
        {
            if (id != tornament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tornament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TornamentExists(tornament.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTournaments));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId);
            ViewData["GameId9"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId9);
            ViewData["GameId10"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId10);
            ViewData["GameId11"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId11);
            ViewData["GameId12"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId12);
            ViewData["GameId13"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId13);
            ViewData["GameId14"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId14);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId1);
            ViewData["GameId2"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId2);
            ViewData["GameId3"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId3);
            ViewData["GameId4"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId4);
            ViewData["GameId5"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId5);
            ViewData["GameId6"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId6);
            ViewData["GameId7"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId7);
            ViewData["GameId8"] = new SelectList(_context.Game, "Id", "GameNumber", tornament.GameId8);
            ViewData["TournamentTypeId"] = new SelectList(_context.Set<TournamentType>(), "Id", "TournamentTypeName", tornament.TournamentTypeId);
            return View(tornament);
        }

        // GET: Tornaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tornament = await _context.Tornament
               .Include(t => t.Game1)
                .Include(t => t.Game1.Arena)
                .Include(t => t.Game10)
                .Include(t => t.Game11)
                .Include(t => t.Game12)
                .Include(t => t.Game13)
                .Include(t => t.Game14)
                .Include(t => t.Game15)
                .Include(t => t.Game2)
                .Include(t => t.Game3)
                .Include(t => t.Game4)
                .Include(t => t.Game5)
                .Include(t => t.Game6)
                .Include(t => t.Game7)
                .Include(t => t.Game8)
                .Include(t => t.Game9)
                .Include(t => t.TournamentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tornament == null)
            {
                return NotFound();
            }

            return View(tornament);
        }

        // POST: Tornaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tornament = await _context.Tornament.FindAsync(id);
            _context.Tornament.Remove(tornament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListTournaments));
        }

        private bool TornamentExists(int id)
        {
            return _context.Tornament.Any(e => e.Id == id);
        }
    }
}

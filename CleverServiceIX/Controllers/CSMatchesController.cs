using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.CleverServiceIX.DataModels;
using DAIF2020.Data;
using DAIF2020.CleverServiceIX.ViewModels;

namespace DAIF2020.CleverServiceIX.Controllers
{
    public class CSMatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CSMatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CSMatches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CSMatch
                .Include(c => c.Arena)
                .Include(c => c.AwayTeam)
                .Include(c => c.HD1)
                .Include(c => c.HD2)
                .Include(c => c.HomeTeam)
                .Include(c => c.LD1)
                .Include(c => c.LD2)
                .Include(c => c.PaymentStatus)
                .Include(c => c.SCMatchStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: CSMatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSMatch = await _context.CSMatch
                .Include(c => c.Arena)
                .Include(c => c.AwayTeam)
                .Include(c => c.HD1)
                .Include(c => c.HD2)
                .Include(c => c.HomeTeam)
                .Include(c => c.LD1)
                .Include(c => c.LD2)
                .Include(c => c.PaymentStatus)
                .Include(c => c.SCMatchStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cSMatch == null)
            {
                return NotFound();
            }

            return View(cSMatch);
        }

        // GET: CSMatches/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PaymentStatusId"] = new SelectList(_context.Set<PaymentStatus>(), "Id", "PaymentStatusName");
            ViewData["CSMatchStatusId"] = new SelectList(_context.Set<SCMatchStatus>(), "Id", "CSMatchStatusName");
            return View();
        }

        // POST: CSMatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTimeMatch,TSMNumber,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,CSMatchStatusId,PaymentStatusId,PersonId,PersonId1,PersonId2,PersonId3")] CSMatch cSMatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cSMatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", cSMatch.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", cSMatch.TeamId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", cSMatch.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId3);
            ViewData["PaymentStatusId"] = new SelectList(_context.Set<PaymentStatus>(), "Id", "PaymentStatusName", cSMatch.PaymentStatusId);
            ViewData["CSMatchStatusId"] = new SelectList(_context.Set<SCMatchStatus>(), "Id", "CSMatchStatusName", cSMatch.CSMatchStatusId);
            return View(cSMatch);
        }

        // GET: CSMatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSMatch = await _context.CSMatch.FindAsync(id);
            if (cSMatch == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", cSMatch.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", cSMatch.TeamId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", cSMatch.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId3);
            ViewData["PaymentStatusId"] = new SelectList(_context.Set<PaymentStatus>(), "Id", "PaymentStatusName", cSMatch.PaymentStatusId);
            ViewData["CSMatchStatusId"] = new SelectList(_context.Set<SCMatchStatus>(), "Id", "CSMatchStatusName", cSMatch.CSMatchStatusId);
            return View(cSMatch);
        }

        // POST: CSMatches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTimeMatch,TSMNumber,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,CSMatchStatusId,PaymentStatusId,PersonId,PersonId1,PersonId2,PersonId3")] CSMatch cSMatch)
        {
            if (id != cSMatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cSMatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CSMatchExists(cSMatch.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", cSMatch.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", cSMatch.TeamId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", cSMatch.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", cSMatch.PersonId3);
            ViewData["PaymentStatusId"] = new SelectList(_context.Set<PaymentStatus>(), "Id", "PaymentStatusName", cSMatch.PaymentStatusId);
            ViewData["CSMatchStatusId"] = new SelectList(_context.Set<SCMatchStatus>(), "Id", "CSMatchStatusName", cSMatch.CSMatchStatusId);
            return View(cSMatch);
        }

        // GET: CSMatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSMatch = await _context.CSMatch
                .Include(c => c.Arena)
                .Include(c => c.AwayTeam)
                .Include(c => c.HD1)
                .Include(c => c.HD2)
                .Include(c => c.HomeTeam)
                .Include(c => c.LD1)
                .Include(c => c.LD2)
                .Include(c => c.PaymentStatus)
                .Include(c => c.SCMatchStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cSMatch == null)
            {
                return NotFound();
            }

            return View(cSMatch);
        }

        // POST: CSMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cSMatch = await _context.CSMatch.FindAsync(id);
            _context.CSMatch.Remove(cSMatch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CSMatchExists(int id)
        {
            return _context.CSMatch.Any(e => e.Id == id);
        }
    }
}

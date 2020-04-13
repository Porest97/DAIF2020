using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.SRHLStats2020.Models.DataModels;
using DAIF2020.SRHLStats2020.Models.ViewModels;

namespace DAIF2020.SRHLStats2020.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Match
                .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.HD1)
                .Include(m => m.HD2)
                .Include(m => m.HomeTeam)
                .Include(m => m.LD1)
                .Include(m => m.LD2)
                .Include(m => m.MatchCategory)
                .Include(m => m.MatchStatus)
                .Include(m => m.MatchType)
                .Include(m => m.Series);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListMatches
        public IActionResult ListMatches()
        {
            var matchesViewModel = new MatchesViewModel()
            {
                Matches = _context.Match
                 .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.MatchCategory)
                .Include(m => m.MatchStatus)
                .Include(m => m.MatchType)
                .Include(m => m.Series)
                .Include(m => m.HD1)
                .Include(m => m.HD2)
                .Include(m => m.HomeTeam)
                .Include(m => m.LD1)
                .Include(m => m.LD2)
                //.Include(m => m.MatchStatus).Where(m => m.MatchStatusId == 1)
                .ToList()
            };
            return View(matchesViewModel);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.HD1)
                .Include(m => m.HD2)
                .Include(m => m.HomeTeam)
                .Include(m => m.LD1)
                .Include(m => m.LD2)
                .Include(m => m.MatchCategory)
                .Include(m => m.MatchStatus)
                .Include(m => m.MatchType)
                .Include(m => m.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["LagId1"] = new SelectList(_context.Team, "Id", "LagNamn");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["LagId"] = new SelectList(_context.Team, "Id", "LagNamn");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "MatchCategoryName");
            ViewData["MatchStatusId"] = new SelectList(_context.Set<MatchStatus>(), "Id", "MatchStatusName");
            ViewData["MatchTypeId"] = new SelectList(_context.Set<MatchType>(), "Id", "MatchTupeName");
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchDateTime,MatchNumber,TSMNumber,MatchCategoryId,MatchStatusId,MatchTypeId,SeriesId,ArenaId,LagId,LagId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListMatches));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", match.ArenaId);
            ViewData["LagId1"] = new SelectList(_context.Team, "Id", "LagNamne", match.LagId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId1);
            ViewData["LagId"] = new SelectList(_context.Team, "Id", "LagNamn", match.LagId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId3);
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "MatchCategoryName", match.MatchCategoryId);
            ViewData["MatchStatusId"] = new SelectList(_context.Set<MatchStatus>(), "Id", "MatchStatusName", match.MatchStatusId);
            ViewData["MatchTypeId"] = new SelectList(_context.Set<MatchType>(), "Id", "MatchTypeName", match.MatchTypeId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", match.SeriesId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", match.ArenaId);
            ViewData["LagId1"] = new SelectList(_context.Team, "Id", "LagNamne", match.LagId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId1);
            ViewData["LagId"] = new SelectList(_context.Team, "Id", "LagNamn", match.LagId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId3);
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "MatchCategoryName", match.MatchCategoryId);
            ViewData["MatchStatusId"] = new SelectList(_context.Set<MatchStatus>(), "Id", "MatchStatusName", match.MatchStatusId);
            ViewData["MatchTypeId"] = new SelectList(_context.Set<MatchType>(), "Id", "MatchTypeName", match.MatchTypeId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", match.SeriesId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchDateTime,MatchNumber,TSMNumber,MatchCategoryId,MatchStatusId,MatchTypeId,SeriesId,ArenaId,LagId,LagId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListMatches));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", match.ArenaId);
            ViewData["LagId1"] = new SelectList(_context.Team, "Id", "LagNamne", match.LagId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId1);
            ViewData["LagId"] = new SelectList(_context.Team, "Id", "LagNamn", match.LagId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", match.PersonId3);
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "MatchCategoryName", match.MatchCategoryId);
            ViewData["MatchStatusId"] = new SelectList(_context.Set<MatchStatus>(), "Id", "MatchStatusName", match.MatchStatusId);
            ViewData["MatchTypeId"] = new SelectList(_context.Set<MatchType>(), "Id", "MatchTypeName", match.MatchTypeId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", match.SeriesId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.HD1)
                .Include(m => m.HD2)
                .Include(m => m.HomeTeam)
                .Include(m => m.LD1)
                .Include(m => m.LD2)
                .Include(m => m.MatchCategory)
                .Include(m => m.MatchStatus)
                .Include(m => m.MatchType)
                .Include(m => m.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Match.FindAsync(id);
            _context.Match.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListMatches));
        }

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.Id == id);
        }
    }
}

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
    public class TeamRostersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamRostersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeamRosters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeamRoster
                .Include(t => t.AssCoach)
                .Include(t => t.GM)
                .Include(t => t.HeadCoach);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListTeamRosters()
        {


            var teamRostersViewModel = new TeamRostersViewModel()
            {
                TeamRosters = _context.TeamRoster
                 .Include(t => t.AssCoach)
                 .Include(t => t.GM)
                 .Include(t => t.HeadCoach)
                 .ToList()
            };
            return View(teamRostersViewModel);
        }

        // GET: TeamRosters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamRoster = await _context.TeamRoster
                .Include(t => t.AssCoach)
                .Include(t => t.GM)
                .Include(t => t.HeadCoach)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamRoster == null)
            {
                return NotFound();
            }

            return View(teamRoster);
        }

        // GET: TeamRosters/Create
        public IActionResult Create()
        {
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: TeamRosters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamRosterName,PersonId,PersonId1,PersonId2")] TeamRoster teamRoster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamRoster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTeamRosters));
            }
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId2);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId1);
            return View(teamRoster);
        }

        // GET: TeamRosters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamRoster = await _context.TeamRoster.FindAsync(id);
            if (teamRoster == null)
            {
                return NotFound();
            }
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId2);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId1);
            return View(teamRoster);
        }

        // POST: TeamRosters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamRosterName,PersonId,PersonId1,PersonId2")] TeamRoster teamRoster)
        {
            if (id != teamRoster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamRoster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamRosterExists(teamRoster.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTeamRosters));
            }
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId2);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", teamRoster.PersonId1);
            return View(teamRoster);
        }

        // GET: TeamRosters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamRoster = await _context.TeamRoster
                .Include(t => t.AssCoach)
                .Include(t => t.GM)
                .Include(t => t.HeadCoach)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamRoster == null)
            {
                return NotFound();
            }

            return View(teamRoster);
        }

        // POST: TeamRosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamRoster = await _context.TeamRoster.FindAsync(id);
            _context.TeamRoster.Remove(teamRoster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListTeamRosters));
        }

        private bool TeamRosterExists(int id)
        {
            return _context.TeamRoster.Any(e => e.Id == id);
        }
    }
}

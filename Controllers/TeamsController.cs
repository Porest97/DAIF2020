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
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Team
                .Include(t => t.Arena)
                .Include(t => t.Club)
                .Include(t => t.Club.Arena)
                .Include(t => t.District)
                .Include(t => t.Series)
                .Include(t => t.TeamRoster)
                .Include(t => t.TeamStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListTeams()
        {


            var teamsViewModel = new TeamsViewModel()
            {
                Teams = _context.Team
                 .Include(t => t.Arena)
                 .Include(t => t.Club)
                 .Include(t => t.Club.Arena)
                 .Include(t => t.District)
                 .Include(t => t.Series)
                 .Include(t => t.TeamRoster)
                 .Include(t => t.TeamStatus)
                 .ToList()
            };
            return View(teamsViewModel);
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(t => t.Arena)
                .Include(t => t.Club)
                .Include(t => t.Club.Arena)
                .Include(t => t.District)
                .Include(t => t.Series)
                .Include(t => t.TeamRoster)
                .Include(t => t.TeamStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName");
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName");
            ViewData["TeamRosterId"] = new SelectList(_context.Set<TeamRoster>(), "Id", "TeamRosterName");
            ViewData["TeamStatusId"] = new SelectList(_context.TeamStatus, "Id", "TeamStatusName");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName,ClubId,DistrictId,ArenaId,SeriesId,TeamStatusId,TeamRosterId")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTeams));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", team.ArenaId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", team.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", team.DistrictId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", team.SeriesId);
            ViewData["TeamRosterId"] = new SelectList(_context.Set<TeamRoster>(), "Id", "TeamRosterName", team.TeamRosterId);
            ViewData["TeamStatusId"] = new SelectList(_context.TeamStatus, "Id", "TeamStatusName", team.TeamStatusId);
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", team.ArenaId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", team.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", team.DistrictId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", team.SeriesId);
            ViewData["TeamRosterId"] = new SelectList(_context.Set<TeamRoster>(), "Id", "TeamRosterName", team.TeamRosterId);
            ViewData["TeamStatusId"] = new SelectList(_context.TeamStatus, "Id", "TeamStatusName", team.TeamStatusId);
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,ClubId,DistrictId,ArenaId,SeriesId,TeamStatusId,TeamRosterId")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTeams));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", team.ArenaId);
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", team.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", team.DistrictId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", team.SeriesId);
            ViewData["TeamRosterId"] = new SelectList(_context.Set<TeamRoster>(), "Id", "TeamRosterName", team.TeamRosterId);
            ViewData["TeamStatusId"] = new SelectList(_context.TeamStatus, "Id", "TeamStatusName", team.TeamStatusId);
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(t => t.Arena)
                .Include(t => t.Club)
                .Include(t => t.Club.Arena)
                .Include(t => t.District)
                .Include(t => t.Series)
                .Include(t => t.TeamRoster)
                .Include(t => t.TeamStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListTeams));
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
    }
}

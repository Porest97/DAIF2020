using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.SettingModels;
using DAIF2020.Models.ViewModels;

namespace DAIF2020.Controllers.SettingsControllers
{
    public class TeamStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeamStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamStatus.ToListAsync());
        }

        public IActionResult ListTeamStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                TeamStatuses = _context.TeamStatus.ToList()
            };
            return View(settingsViewModel);
        }

        // GET: TeamStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamStatus = await _context.TeamStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamStatus == null)
            {
                return NotFound();
            }

            return View(teamStatus);
        }

        // GET: TeamStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamStatusName")] TeamStatus teamStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTeamStatuses));
            }
            return View(teamStatus);
        }

        // GET: TeamStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamStatus = await _context.TeamStatus.FindAsync(id);
            if (teamStatus == null)
            {
                return NotFound();
            }
            return View(teamStatus);
        }

        // POST: TeamStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamStatusName")] TeamStatus teamStatus)
        {
            if (id != teamStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamStatusExists(teamStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTeamStatuses));
            }
            return View(teamStatus);
        }

        // GET: TeamStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamStatus = await _context.TeamStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamStatus == null)
            {
                return NotFound();
            }

            return View(teamStatus);
        }

        // POST: TeamStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamStatus = await _context.TeamStatus.FindAsync(id);
            _context.TeamStatus.Remove(teamStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListTeamStatuses));
        }

        private bool TeamStatusExists(int id)
        {
            return _context.TeamStatus.Any(e => e.Id == id);
        }
    }
}

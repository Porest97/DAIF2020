using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Planner.Models.DataModels;
using DAIF2020.Planner.Models.ViewModels;

namespace DAIF2020.Controllers.PlannerControllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context
                .Activity.Include(a => a.ActivityStatus)
                .Include(a => a.Game)
                .Include(a => a.Person)
                .Include(a => a.Meeting);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListActivities()
        {
            var activitiesViewModel = new ActivitiesViewModel()
            {
                Activities = _context.Activity
                .Include(a => a.ActivityStatus)
                .Include(a => a.Game)
                .Include(a => a.Game.GameCategory)
                .Include(a => a.Game.Arena)
                .Include(a => a.Meeting)
                .Include(a => a.Meeting.Location)
                .Include(a => a.Person).Where(a => a.ActivityStatusId == 1 && a.PersonId > 2)
                .ToList()
            };
            return View(activitiesViewModel);
        }

        public IActionResult ListActivitiesDone()
        {
            var activitiesViewModel = new ActivitiesViewModel()
            {
                Activities = _context.Activity
                .Include(a => a.ActivityStatus)
                .Include(a => a.Game)
                .Include(a => a.Game.GameCategory)
                .Include(a => a.Game.Arena)
                .Include(a => a.Meeting)
                .Include(a => a.Meeting.Location)
                .Include(a => a.Person).Where(a => a.ActivityStatusId == 2)
                .ToList()
            };
            return View(activitiesViewModel);
        }

        public IActionResult ListActivitiesPO()
        {
            var activitiesViewModel = new ActivitiesViewModel()
            {
                Activities = _context.Activity
                .Include(a => a.ActivityStatus)
                .Include(a => a.Game)
                .Include(a => a.Game.GameCategory)
                .Include(a => a.Game.Arena)
                .Include(a => a.Meeting)
                .Include(a => a.Meeting.Location)
                .Include(a => a.Person).Where(a => a.PersonId == 2 && a.ActivityStatusId == 1)
                .ToList()
            };
            return View(activitiesViewModel);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .Include(a => a.ActivityStatus)
                .Include(a => a.Game)
                .Include(a => a.Game.GameCategory)
                .Include(a => a.Meeting)
                .Include(a => a.Meeting.Location)
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatus, "Id", "ActivityStatusName");
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["MeetingId"] = new SelectList(_context.Meeting, "Id", "MeetingName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActivityName,ActivityStatusId,FromDateTime,ToDateTime,GameId,PersonId,MeetingId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListActivities));
            }
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatus, "Id", "ActivityStatusName", activity.ActivityStatusId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", activity.GameId);
            ViewData["MeetingId"] = new SelectList(_context.Meeting, "Id", "MeetingName", activity.MeetingId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", activity.PersonId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatus, "Id", "ActivityStatusName", activity.ActivityStatusId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", activity.GameId);
            ViewData["MeetingId"] = new SelectList(_context.Meeting, "Id", "MeetingName", activity.MeetingId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", activity.PersonId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActivityName,ActivityStatusId,FromDateTime,ToDateTime,GameId,PersonId,MeetingId")] Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListActivities));
            }
            ViewData["ActivityStatusId"] = new SelectList(_context.ActivityStatus, "Id", "ActivityStatusName", activity.ActivityStatusId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", activity.GameId);
            ViewData["MeetingId"] = new SelectList(_context.Meeting, "Id", "MeetingName", activity.MeetingId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", activity.PersonId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .Include(a => a.ActivityStatus)
                .Include(a => a.Game)
                .Include(a => a.Meeting)
                .Include(a => a.Meeting.Location)
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activity.FindAsync(id);
            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListActivities));
        }

        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.Id == id);
        }
    }
}

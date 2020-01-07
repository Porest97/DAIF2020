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
    public class ActivityStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActivityStatus
        public IActionResult ListActivityStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                ActivityStatuses = _context.ActivityStatus.ToList()
            };
            return View(settingsViewModel);
        }

        // GET: ActivityStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityStatus.ToListAsync());
        }

        // GET: ActivityStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityStatus = await _context.ActivityStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityStatus == null)
            {
                return NotFound();
            }

            return View(activityStatus);
        }

        // GET: ActivityStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActivityStatusName")] ActivityStatus activityStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListActivityStatuses));
            }
            return View(activityStatus);
        }

        // GET: ActivityStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityStatus = await _context.ActivityStatus.FindAsync(id);
            if (activityStatus == null)
            {
                return NotFound();
            }
            return View(activityStatus);
        }

        // POST: ActivityStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActivityStatusName")] ActivityStatus activityStatus)
        {
            if (id != activityStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityStatusExists(activityStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListActivityStatuses));
            }
            return View(activityStatus);
        }

        // GET: ActivityStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityStatus = await _context.ActivityStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityStatus == null)
            {
                return NotFound();
            }

            return View(activityStatus);
        }

        // POST: ActivityStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityStatus = await _context.ActivityStatus.FindAsync(id);
            _context.ActivityStatus.Remove(activityStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListActivityStatuses));
        }

        private bool ActivityStatusExists(int id)
        {
            return _context.ActivityStatus.Any(e => e.Id == id);
        }
    }
}

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
    public class SeriesStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeriesStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SeriesStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.SeriesStatus.ToListAsync());
        }

        public IActionResult ListSeriesStatuses()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                SeriesStatuses = _context.SeriesStatus.ToList()
            };
            return View(settingsViewModel);
        }

        // GET: SeriesStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesStatus = await _context.SeriesStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seriesStatus == null)
            {
                return NotFound();
            }

            return View(seriesStatus);
        }

        // GET: SeriesStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeriesStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SeriesStatusName")] SeriesStatus seriesStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seriesStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSeriesStatuses));
            }
            return View(seriesStatus);
        }

        // GET: SeriesStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesStatus = await _context.SeriesStatus.FindAsync(id);
            if (seriesStatus == null)
            {
                return NotFound();
            }
            return View(seriesStatus);
        }

        // POST: SeriesStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SeriesStatusName")] SeriesStatus seriesStatus)
        {
            if (id != seriesStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seriesStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesStatusExists(seriesStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSeriesStatuses));
            }
            return View(seriesStatus);
        }

        // GET: SeriesStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesStatus = await _context.SeriesStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seriesStatus == null)
            {
                return NotFound();
            }

            return View(seriesStatus);
        }

        // POST: SeriesStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seriesStatus = await _context.SeriesStatus.FindAsync(id);
            _context.SeriesStatus.Remove(seriesStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSeriesStatuses));
        }

        private bool SeriesStatusExists(int id)
        {
            return _context.SeriesStatus.Any(e => e.Id == id);
        }
    }
}

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

namespace DAIF2020.Controllers
{
    public class ArenasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArenasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arenas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Arena.Include(a => a.ArenaStatus).Include(a => a.District);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Arenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena
                .Include(a => a.ArenaStatus)
                .Include(a => a.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arena == null)
            {
                return NotFound();
            }

            return View(arena);
        }

        // GET: Arenas/Create
        public IActionResult Create()
        {
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "Id");
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "Id");
            return View();
        }

        // POST: Arenas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArenaNumber,ArenaName,StreetAddress,ZipCode,City,Country,DistrictId,ArenaStatusId")] Arena arena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "Id", arena.ArenaStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "Id", arena.DistrictId);
            return View(arena);
        }

        // GET: Arenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena.FindAsync(id);
            if (arena == null)
            {
                return NotFound();
            }
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "Id", arena.ArenaStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "Id", arena.DistrictId);
            return View(arena);
        }

        // POST: Arenas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArenaNumber,ArenaName,StreetAddress,ZipCode,City,Country,DistrictId,ArenaStatusId")] Arena arena)
        {
            if (id != arena.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArenaExists(arena.Id))
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
            ViewData["ArenaStatusId"] = new SelectList(_context.Set<ArenaStatus>(), "Id", "Id", arena.ArenaStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "Id", arena.DistrictId);
            return View(arena);
        }

        // GET: Arenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arena = await _context.Arena
                .Include(a => a.ArenaStatus)
                .Include(a => a.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arena == null)
            {
                return NotFound();
            }

            return View(arena);
        }

        // POST: Arenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arena = await _context.Arena.FindAsync(id);
            _context.Arena.Remove(arena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArenaExists(int id)
        {
            return _context.Arena.Any(e => e.Id == id);
        }
    }
}

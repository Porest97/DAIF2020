﻿using System;
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
    public class ClubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Club
                .Include(c => c.Arena)
                .Include(c => c.ClubStatus)
                .Include(c => c.District);
            return View(await applicationDbContext.ToListAsync());
        }

        // List Clubs
        public IActionResult ListClubs()
        {


            var clubsViewModel = new ClubsViewModel()
            {
                Clubs = _context.Club
                       .Include(c => c.Arena)
                       .Include(c => c.ClubStatus)
                       .Include(c => c.District)
                       .ToList()
            };
            return View(clubsViewModel);
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Club
                .Include(c => c.Arena)
                .Include(c => c.ClubStatus)
                .Include(c => c.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // GET: Clubs/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["ClubStatusId"] = new SelectList(_context.Set<ClubStatus>(), "Id", "ClubStatusName");
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName");
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClubNumber,ClubName,ShortName,StreetAddress,ZipCode,City,Country,DistrictId,ArenaId,ClubStatusId")] Club club)
        {
            if (ModelState.IsValid)
            {
                _context.Add(club);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListClubs));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", club.ArenaId);
            ViewData["ClubStatusId"] = new SelectList(_context.Set<ClubStatus>(), "Id", "ClubStatusName", club.ClubStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName", club.DistrictId);
            return View(club);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Club.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", club.ArenaId);
            ViewData["ClubStatusId"] = new SelectList(_context.Set<ClubStatus>(), "Id", "ClubStatusName", club.ClubStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName", club.DistrictId);
            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClubNumber,ClubName,ShortName,StreetAddress,ZipCode,City,Country,DistrictId,ArenaId,ClubStatusId")] Club club)
        {
            if (id != club.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(club);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(club.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListClubs));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", club.ArenaId);
            ViewData["ClubStatusId"] = new SelectList(_context.Set<ClubStatus>(), "Id", "ClubStatusName", club.ClubStatusId);
            ViewData["DistrictId"] = new SelectList(_context.Set<District>(), "Id", "DistrictName", club.DistrictId);
            return View(club);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Club
                .Include(c => c.Arena)
                .Include(c => c.ClubStatus)
                .Include(c => c.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var club = await _context.Club.FindAsync(id);
            _context.Club.Remove(club);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListClubs));
        }

        private bool ClubExists(int id)
        {
            return _context.Club.Any(e => e.Id == id);
        }
    }
}

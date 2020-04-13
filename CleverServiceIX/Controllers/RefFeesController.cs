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
    public class RefFeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefFeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefFees
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefFees.ToListAsync());
        }
        public IActionResult ListRefFees()
        {
            var refFeesViewModel = new RefFeesViewModel()
            {
                RefFees = _context.RefFees                
                .ToList()
            };
            return View(refFeesViewModel);
        }

        // GET: RefFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refFees = await _context.RefFees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refFees == null)
            {
                return NotFound();
            }

            return View(refFees);
        }

        // GET: RefFees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,UDZ,HD,LD")] RefFees refFees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refFees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListRefFees));
            }
            return View(refFees);
        }

        // GET: RefFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refFees = await _context.RefFees.FindAsync(id);
            if (refFees == null)
            {
                return NotFound();
            }
            return View(refFees);
        }

        // POST: RefFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,UDZ,HD,LD")] RefFees refFees)
        {
            if (id != refFees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refFees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefFeesExists(refFees.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListRefFees));
            }
            return View(refFees);
        }

        // GET: RefFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refFees = await _context.RefFees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refFees == null)
            {
                return NotFound();
            }

            return View(refFees);
        }

        // POST: RefFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refFees = await _context.RefFees.FindAsync(id);
            _context.RefFees.Remove(refFees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListRefFees));
        }

        private bool RefFeesExists(int id)
        {
            return _context.RefFees.Any(e => e.Id == id);
        }
    }
}

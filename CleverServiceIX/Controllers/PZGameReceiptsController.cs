using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.CleverServiceIX.DataModels;
using DAIF2020.Data;

namespace DAIF2020.CleverServiceIX.Controllers
{
    public class PZGameReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PZGameReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PZGameReceipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PZGameReceipt.Include(p => p.PZGame).Include(p => p.ReceiptCategory).Include(p => p.ReceiptStatus).Include(p => p.ReceiptType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PZGameReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZGameReceipt = await _context.PZGameReceipt
                .Include(p => p.PZGame)
                .Include(p => p.ReceiptCategory)
                .Include(p => p.ReceiptStatus)
                .Include(p => p.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pZGameReceipt == null)
            {
                return NotFound();
            }

            return View(pZGameReceipt);
        }

        // GET: PZGameReceipts/Create
        public IActionResult Create()
        {
            ViewData["PZGameId"] = new SelectList(_context.PZGame, "Id", "Id");
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "Id");
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "Id");
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "Id");
            return View();
        }

        // POST: PZGameReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PZGameId,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,UDZ1Fee,UDZ2Fee,UDZ3Fee,UDZ4Fee")] PZGameReceipt pZGameReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pZGameReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PZGameId"] = new SelectList(_context.PZGame, "Id", "Id", pZGameReceipt.PZGameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "Id", pZGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "Id", pZGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "Id", pZGameReceipt.ReceiptTypeId);
            return View(pZGameReceipt);
        }

        // GET: PZGameReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZGameReceipt = await _context.PZGameReceipt.FindAsync(id);
            if (pZGameReceipt == null)
            {
                return NotFound();
            }
            ViewData["PZGameId"] = new SelectList(_context.PZGame, "Id", "Id", pZGameReceipt.PZGameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "Id", pZGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "Id", pZGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "Id", pZGameReceipt.ReceiptTypeId);
            return View(pZGameReceipt);
        }

        // POST: PZGameReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PZGameId,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,UDZ1Fee,UDZ2Fee,UDZ3Fee,UDZ4Fee")] PZGameReceipt pZGameReceipt)
        {
            if (id != pZGameReceipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pZGameReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PZGameReceiptExists(pZGameReceipt.Id))
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
            ViewData["PZGameId"] = new SelectList(_context.PZGame, "Id", "Id", pZGameReceipt.PZGameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "Id", pZGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "Id", pZGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "Id", pZGameReceipt.ReceiptTypeId);
            return View(pZGameReceipt);
        }

        // GET: PZGameReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZGameReceipt = await _context.PZGameReceipt
                .Include(p => p.PZGame)
                .Include(p => p.ReceiptCategory)
                .Include(p => p.ReceiptStatus)
                .Include(p => p.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pZGameReceipt == null)
            {
                return NotFound();
            }

            return View(pZGameReceipt);
        }

        // POST: PZGameReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pZGameReceipt = await _context.PZGameReceipt.FindAsync(id);
            _context.PZGameReceipt.Remove(pZGameReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PZGameReceiptExists(int id)
        {
            return _context.PZGameReceipt.Any(e => e.Id == id);
        }
    }
}

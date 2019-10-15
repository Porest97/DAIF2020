using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.SettingModels;

namespace DAIF2020.Controllers.SettingsControllers
{
    public class ReceiptStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiptStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReceiptStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReceiptStatus.ToListAsync());
        }

        // GET: ReceiptStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptStatus = await _context.ReceiptStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptStatus == null)
            {
                return NotFound();
            }

            return View(receiptStatus);
        }

        // GET: ReceiptStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReceiptStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptStatusName")] ReceiptStatus receiptStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiptStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receiptStatus);
        }

        // GET: ReceiptStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptStatus = await _context.ReceiptStatus.FindAsync(id);
            if (receiptStatus == null)
            {
                return NotFound();
            }
            return View(receiptStatus);
        }

        // POST: ReceiptStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptStatusName")] ReceiptStatus receiptStatus)
        {
            if (id != receiptStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptStatusExists(receiptStatus.Id))
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
            return View(receiptStatus);
        }

        // GET: ReceiptStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptStatus = await _context.ReceiptStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptStatus == null)
            {
                return NotFound();
            }

            return View(receiptStatus);
        }

        // POST: ReceiptStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receiptStatus = await _context.ReceiptStatus.FindAsync(id);
            _context.ReceiptStatus.Remove(receiptStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptStatusExists(int id)
        {
            return _context.ReceiptStatus.Any(e => e.Id == id);
        }
    }
}

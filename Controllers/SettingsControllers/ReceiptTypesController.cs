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
    public class ReceiptTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiptTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReceiptTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReceiptType.ToListAsync());
        }

        // GET: ReceiptTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptType = await _context.ReceiptType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptType == null)
            {
                return NotFound();
            }

            return View(receiptType);
        }

        // GET: ReceiptTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReceiptTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptTypeName")] ReceiptType receiptType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiptType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receiptType);
        }

        // GET: ReceiptTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptType = await _context.ReceiptType.FindAsync(id);
            if (receiptType == null)
            {
                return NotFound();
            }
            return View(receiptType);
        }

        // POST: ReceiptTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptTypeName")] ReceiptType receiptType)
        {
            if (id != receiptType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptTypeExists(receiptType.Id))
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
            return View(receiptType);
        }

        // GET: ReceiptTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptType = await _context.ReceiptType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptType == null)
            {
                return NotFound();
            }

            return View(receiptType);
        }

        // POST: ReceiptTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receiptType = await _context.ReceiptType.FindAsync(id);
            _context.ReceiptType.Remove(receiptType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptTypeExists(int id)
        {
            return _context.ReceiptType.Any(e => e.Id == id);
        }
    }
}

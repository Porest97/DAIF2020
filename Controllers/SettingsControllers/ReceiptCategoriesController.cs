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
    public class ReceiptCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiptCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReceiptCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReceiptCategory.ToListAsync());
        }

        public IActionResult ListReceiptCategories()
        {
            var settingsViewModel = new SettingsViewModel()
            {
                ReceiptCategories = _context.ReceiptCategory.ToList()
            };
            return View(settingsViewModel);
        }

        // GET: ReceiptCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptCategory = await _context.ReceiptCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptCategory == null)
            {
                return NotFound();
            }

            return View(receiptCategory);
        }

        // GET: ReceiptCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReceiptCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptCategoryName")] ReceiptCategory receiptCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiptCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListReceiptCategories));
            }
            return View(receiptCategory);
        }

        // GET: ReceiptCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptCategory = await _context.ReceiptCategory.FindAsync(id);
            if (receiptCategory == null)
            {
                return NotFound();
            }
            return View(receiptCategory);
        }

        // POST: ReceiptCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptCategoryName")] ReceiptCategory receiptCategory)
        {
            if (id != receiptCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptCategoryExists(receiptCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListReceiptCategories));
            }
            return View(receiptCategory);
        }

        // GET: ReceiptCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptCategory = await _context.ReceiptCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptCategory == null)
            {
                return NotFound();
            }

            return View(receiptCategory);
        }

        // POST: ReceiptCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receiptCategory = await _context.ReceiptCategory.FindAsync(id);
            _context.ReceiptCategory.Remove(receiptCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListReceiptCategories));
        }

        private bool ReceiptCategoryExists(int id)
        {
            return _context.ReceiptCategory.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.TheLab.Models.DataModels;
using DAIF2020.TheLab.Models.VeiwModels;

namespace DAIF2020.TheLab.Controllers
{
    public class WeeklyReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeeklyReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeeklyReceipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WeeklyReciept
                .Include(w => w.ReceiptStatus)
                .Include(w => w.Referee);
            return View(await applicationDbContext.ToListAsync());
        }

        //ListWeeklyReceipts - Created
        public IActionResult ListWeeklyReceipts()
        {
            var weeklyReceiptsViewModel = new WeeklyReceiptsViewModel()
            {
                WeeklyReceipts = _context.WeeklyReciept
                .Include(w => w.ReceiptStatus)
                .Include(w => w.Referee).Where(w=>w.ReceiptStatusId == 1)
                .ToList()
            };
            return View(weeklyReceiptsViewModel);
        }

        // GET: WeeklyReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyReceipt = await _context.WeeklyReciept
                .Include(w => w.ReceiptStatus)
                .Include(w => w.Referee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weeklyReceipt == null)
            {
                return NotFound();
            }

            return View(weeklyReceipt);
        }

        // GET: WeeklyReceipts/Create
        public IActionResult Create()
        {
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName");
            return View();
        }

        // POST: WeeklyReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptStatusId,PersonId,StartDate,EndDate")] WeeklyReceipt weeklyReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weeklyReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListWeeklyReceipts));
            }
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", weeklyReceipt.ReceiptStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", weeklyReceipt.PersonId);
            return View(weeklyReceipt);
        }

        // GET: WeeklyReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyReceipt = await _context.WeeklyReciept.FindAsync(id);
            if (weeklyReceipt == null)
            {
                return NotFound();
            }
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", weeklyReceipt.ReceiptStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", weeklyReceipt.PersonId);
            return View(weeklyReceipt);
        }

        // POST: WeeklyReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptStatusId,PersonId,StartDate,EndDate")] WeeklyReceipt weeklyReceipt)
        {
            if (id != weeklyReceipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weeklyReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeeklyReceiptExists(weeklyReceipt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListWeeklyReceipts));
            }
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", weeklyReceipt.ReceiptStatusId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "CName", weeklyReceipt.PersonId);
            return View(weeklyReceipt);
        }

        // GET: WeeklyReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklyReceipt = await _context.WeeklyReciept
                .Include(w => w.ReceiptStatus)
                .Include(w => w.Referee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weeklyReceipt == null)
            {
                return NotFound();
            }

            return View(weeklyReceipt);
        }

        // POST: WeeklyReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weeklyReceipt = await _context.WeeklyReciept.FindAsync(id);
            _context.WeeklyReciept.Remove(weeklyReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListWeeklyReceipts));
        }

        private bool WeeklyReceiptExists(int id)
        {
            return _context.WeeklyReciept.Any(e => e.Id == id);
        }
    }
}

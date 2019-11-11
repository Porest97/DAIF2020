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
    public class PoolGameReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoolGameReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoolGameReceipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PoolGameReceipt
                .Include(p => p.PoolGame)
                .Include(p => p.PoolGame.Arena)
                // UDZ1 & UDZ2 Include !
                .Include(p => p.PoolGame.ZoneGame1.UDZ1).Include(p => p.PoolGame.ZoneGame1.UDZ2)
                .Include(p => p.PoolGame.ZoneGame2.UDZ1).Include(p => p.PoolGame.ZoneGame2.UDZ2)
                .Include(p => p.PoolGame.ZoneGame3.UDZ1).Include(p => p.PoolGame.ZoneGame3.UDZ2)                
                .Include(p => p.ReceiptCategory)
                .Include(p => p.ReceiptStatus)
                .Include(p => p.ReceiptType);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListPoolGameReceipts()
        {
            var poolGameReceiptsViewModel = new PoolGameReceiptsViewModel()
            {
                PoolGameReceipts = _context.PoolGameReceipt
                .Include(p => p.PoolGame)
                .Include(p => p.PoolGame.Arena)
                // UDZ1 & UDZ2 Include !
                .Include(p => p.PoolGame.ZoneGame1.UDZ1).Include(p => p.PoolGame.ZoneGame1.UDZ2)
                .Include(p => p.PoolGame.ZoneGame2.UDZ1).Include(p => p.PoolGame.ZoneGame2.UDZ2)
                .Include(p => p.PoolGame.ZoneGame3.UDZ1).Include(p => p.PoolGame.ZoneGame3.UDZ2)
                .Include(p => p.ReceiptCategory)
                .Include(p => p.ReceiptStatus)
                .Include(p => p.ReceiptType)
                .ToList()
            };
            return View(poolGameReceiptsViewModel);
        }

        // GET: PoolGameReceeipt !
        public async Task<IActionResult> PoolGameReceipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGameReceipt = await _context.PoolGameReceipt
                .Include(p => p.PoolGame)
                .Include(p => p.PoolGame.Arena)
                .Include(p => p.PoolGame.HostingTeam)
                // ZoneGame1 TeamsZ1 & TeamsZ2 Include !
                .Include(p => p.PoolGame.ZoneGame1.HomeTeam1)
                .Include(p => p.PoolGame.ZoneGame1.HomeTeam2)
                .Include(p => p.PoolGame.ZoneGame1.AwayTeam1)
                .Include(p => p.PoolGame.ZoneGame1.AwayTeam2)
                // ZoneGame2 TeamsZ1 & TeamsZ2 Include !
                .Include(p => p.PoolGame.ZoneGame2.HomeTeam1)
                .Include(p => p.PoolGame.ZoneGame2.HomeTeam2)
                .Include(p => p.PoolGame.ZoneGame2.AwayTeam1)
                .Include(p => p.PoolGame.ZoneGame2.AwayTeam2)
                // ZoneGame3 TeamsZ1 & TeamsZ2 Include !
                .Include(p => p.PoolGame.ZoneGame3.HomeTeam1)
                .Include(p => p.PoolGame.ZoneGame3.HomeTeam2)
                .Include(p => p.PoolGame.ZoneGame3.AwayTeam1)
                .Include(p => p.PoolGame.ZoneGame3.AwayTeam2)
                // UDZ1 & UDZ2 Include !
                .Include(p => p.PoolGame.ZoneGame1.UDZ1)
                .Include(p => p.PoolGame.ZoneGame1.UDZ2)
                .Include(p => p.PoolGame.ZoneGame2.UDZ1)
                .Include(p => p.PoolGame.ZoneGame2.UDZ2)
                .Include(p => p.PoolGame.ZoneGame3.UDZ1)
                .Include(p => p.PoolGame.ZoneGame3.UDZ2)
                // Zone1 & Zone2 Include !
                .Include(p => p.PoolGame.ZoneGame1.UDZ1)
                .Include(p => p.PoolGame.ZoneGame1.Zone1)
                .Include(p => p.PoolGame.ZoneGame2.UDZ1)
                .Include(p => p.PoolGame.ZoneGame1.Zone2)                
                .Include(p => p.ReceiptCategory)
                .Include(p => p.ReceiptStatus)
                .Include(p => p.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGameReceipt == null)
            {
                return NotFound();
            }

            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGameReceipt = await _context.PoolGameReceipt
               .Include(p => p.PoolGame)
                .Include(p => p.PoolGame.Arena)
                // UDZ1 & UDZ2 Include !
                .Include(p => p.PoolGame.ZoneGame1.UDZ1).Include(p => p.PoolGame.ZoneGame1.UDZ2)
                .Include(p => p.PoolGame.ZoneGame2.UDZ1).Include(p => p.PoolGame.ZoneGame2.UDZ2)
                .Include(p => p.PoolGame.ZoneGame3.UDZ1).Include(p => p.PoolGame.ZoneGame3.UDZ2)
                .Include(p => p.ReceiptCategory)
                .Include(p => p.ReceiptStatus)
                .Include(p => p.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGameReceipt == null)
            {
                return NotFound();
            }

            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Create
        public IActionResult Create()
        {
            ViewData["PoolGameId"] = new SelectList(_context.PoolGame, "Id", "PoolGameName");
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName");
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName");
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName");
            return View();
        }

        // POST: PoolGameReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,PoolGameId,UDZ1Fee,UDZ1TravelKost,UDZ1Alowens,DUZ1LateGameKost,UDZ1Other,UDZ1TotalFee,UDZ2Fee,UDZ2TravelKost,UDZ2Alowens,UDZ2LateGameKost,UDZ2Other,UDZ2TotalFee,PoolGameTotalKost,AmountPaidUDZ1,AmountPaidUDZ2,TotalAmountPaid,TotalAmountToPay")] PoolGameReceipt poolGameReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poolGameReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListPoolGameReceipts));
            }
            ViewData["PoolGameId"] = new SelectList(_context.PoolGame, "Id", "PoolGameName", poolGameReceipt.PoolGameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", poolGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", poolGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", poolGameReceipt.ReceiptTypeId);
            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGameReceipt = await _context.PoolGameReceipt.FindAsync(id);
            if (poolGameReceipt == null)
            {
                return NotFound();
            }
            ViewData["PoolGameId"] = new SelectList(_context.PoolGame, "Id", "PoolGameName", poolGameReceipt.PoolGameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", poolGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", poolGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", poolGameReceipt.ReceiptTypeId);
            return View(poolGameReceipt);
        }

        // POST: PoolGameReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,PoolGameId,UDZ1Fee,UDZ1TravelKost,UDZ1Alowens,DUZ1LateGameKost,UDZ1Other,UDZ1TotalFee,UDZ2Fee,UDZ2TravelKost,UDZ2Alowens,UDZ2LateGameKost,UDZ2Other,UDZ2TotalFee,PoolGameTotalKost,AmountPaidUDZ1,AmountPaidUDZ2,TotalAmountPaid,TotalAmountToPay")] PoolGameReceipt poolGameReceipt)
        {
            if (id != poolGameReceipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poolGameReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoolGameReceiptExists(poolGameReceipt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListPoolGameReceipts));
            }
            ViewData["PoolGameId"] = new SelectList(_context.PoolGame, "Id", "PoolGameName", poolGameReceipt.PoolGameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", poolGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", poolGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", poolGameReceipt.ReceiptTypeId);
            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGameReceipt = await _context.PoolGameReceipt
               .Include(p => p.PoolGame)
                .Include(p => p.PoolGame.Arena)
                // UDZ1 & UDZ2 Include !
                .Include(p => p.PoolGame.ZoneGame1.UDZ1).Include(p => p.PoolGame.ZoneGame1.UDZ2)
                .Include(p => p.PoolGame.ZoneGame2.UDZ1).Include(p => p.PoolGame.ZoneGame2.UDZ2)
                .Include(p => p.PoolGame.ZoneGame3.UDZ1).Include(p => p.PoolGame.ZoneGame3.UDZ2)
                .Include(p => p.ReceiptCategory)
                .Include(p => p.ReceiptStatus)
                .Include(p => p.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGameReceipt == null)
            {
                return NotFound();
            }

            return View(poolGameReceipt);
        }

        // POST: PoolGameReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poolGameReceipt = await _context.PoolGameReceipt.FindAsync(id);
            _context.PoolGameReceipt.Remove(poolGameReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListPoolGameReceipts));
        }

        private bool PoolGameReceiptExists(int id)
        {
            return _context.PoolGameReceipt.Any(e => e.Id == id);
        }
    }
}

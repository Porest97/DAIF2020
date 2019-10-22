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
    public class ZoneGameReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZoneGameReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZoneGameReceipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ZoneGameReceipt
                .Include(z => z.ReceiptCategory)
                .Include(z => z.ReceiptStatus)
                .Include(z => z.ReceiptType)
                .Include(z => z.ZoneGame);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListZoneGameReceipts()
        {
            var zoneGameReceiptsViewModel = new ZoneGameReceiptsViewModel()
            {
                ZoneGameReceipts = _context.ZoneGameReceipt
               .Include(z => z.ReceiptCategory)
                .Include(z => z.ReceiptStatus)
                .Include(z => z.ReceiptType)
                .Include(z => z.ZoneGame)
                .Include(z => z.ZoneGame.Arena)
                .Include(z => z.ZoneGame.UDZ1)
                .Include(z => z.ZoneGame.UDZ2)
                .Include(z => z.ZoneGame.Zone1)
                .Include(z => z.ZoneGame.Zone2)
                .Include(z => z.ZoneGame.HomeTeam1)
                .Include(z => z.ZoneGame.HomeTeam2)
                .Include(z => z.ZoneGame.AwayTeam1)
                .Include(z => z.ZoneGame.AwayTeam2)
                .Include(z => z.ZoneGame.GameCategory)
                .ToList()
            };
            return View(zoneGameReceiptsViewModel);
        }

        // GET: PoolGameReceeipt !
        public async Task<IActionResult> ZoneGameReceipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoneGameReceipt = await _context.ZoneGameReceipt                
                .Include(z => z.ReceiptCategory)
                .Include(z => z.ReceiptStatus)
                .Include(z => z.ReceiptType)
                .Include(z => z.ZoneGame)
                .Include(z => z.ZoneGame.Arena)
                .Include(z => z.ZoneGame.UDZ1)
                .Include(z => z.ZoneGame.UDZ2)
                .Include(z => z.ZoneGame.Zone1)
                .Include(z => z.ZoneGame.Zone2)
                .Include(z => z.ZoneGame.HomeTeam1)
                .Include(z => z.ZoneGame.HomeTeam2)
                .Include(z => z.ZoneGame.AwayTeam1)
                .Include(z => z.ZoneGame.AwayTeam2)
                .Include(z => z.ZoneGame.GameCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoneGameReceipt == null)
            {
                return NotFound();
            }

            return View(zoneGameReceipt);
        }

        // GET: ZoneGameReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoneGameReceipt = await _context.ZoneGameReceipt
                .Include(z => z.ReceiptCategory)
                .Include(z => z.ReceiptStatus)
                .Include(z => z.ReceiptType)
                .Include(z => z.ZoneGame)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoneGameReceipt == null)
            {
                return NotFound();
            }

            return View(zoneGameReceipt);
        }

        // GET: ZoneGameReceipts/Create
        public IActionResult Create()
        {
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName");
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName");
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName");
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName");
            return View();
        }

        // POST: ZoneGameReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,ZoneGameId,UDZ1Fee,UDZ1TravelKost,UDZ1Alowens,DUZ1LateGameKost,UDZ1Other,UDZ1TotalFee,UDZ2Fee,UDZ2TravelKost,UDZ2Alowens,UDZ2LateGameKost,UDZ2Other,UDZ2TotalFee,ZoneGameTotalKost,AmountPaidUDZ1,AmountPaidUDZ2,TotalAmountPaid,TotalAmountToPay")] ZoneGameReceipt zoneGameReceipt)
        {
            if (ModelState.IsValid)
            {
                var applicationDbContext = _context.ZoneGameReceipt
                 .Include(z => z.ReceiptCategory)
                .Include(z => z.ReceiptStatus)
                .Include(z => z.ReceiptType)
                .Include(z => z.ZoneGame)
                .Include(z => z.ZoneGame.Arena)
                .Include(z => z.ZoneGame.UDZ1)
                .Include(z => z.ZoneGame.UDZ2)
                .Include(z => z.ZoneGame.Zone1)
                .Include(z => z.ZoneGame.Zone2)
                .Include(z => z.ZoneGame.HomeTeam1)
                .Include(z => z.ZoneGame.HomeTeam2)
                .Include(z => z.ZoneGame.AwayTeam1)
                .Include(z => z.ZoneGame.AwayTeam2)
                .Include(z => z.ZoneGame.GameCategory);
                zoneGameReceipt.UDZ1TotalFee = zoneGameReceipt.UDZ1Fee + zoneGameReceipt.UDZ1Alowens + zoneGameReceipt.UDZ1Other + zoneGameReceipt.UDZ1TravelKost + zoneGameReceipt.UDZ1LateGameKost;
                zoneGameReceipt.UDZ2TotalFee = zoneGameReceipt.UDZ2Fee + zoneGameReceipt.UDZ2Alowens + zoneGameReceipt.UDZ2Other + zoneGameReceipt.UDZ2TravelKost + zoneGameReceipt.UDZ2LateGameKost;
               

                _context.Add(zoneGameReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListZoneGameReceipts));
            }
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", zoneGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", zoneGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", zoneGameReceipt.ReceiptTypeId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", zoneGameReceipt.ZoneGameId);
            return View(zoneGameReceipt);
        }

        // GET: ZoneGameReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoneGameReceipt = await _context.ZoneGameReceipt.FindAsync(id);
            if (zoneGameReceipt == null)
            {
                return NotFound();
            }
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", zoneGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", zoneGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", zoneGameReceipt.ReceiptTypeId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", zoneGameReceipt.ZoneGameId);
            return View(zoneGameReceipt);
        }

        // POST: ZoneGameReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,ZoneGameId,UDZ1Fee,UDZ1TravelKost,UDZ1Alowens,DUZ1LateGameKost,UDZ1Other,UDZ1TotalFee,UDZ2Fee,UDZ2TravelKost,UDZ2Alowens,UDZ2LateGameKost,UDZ2Other,UDZ2TotalFee,ZoneGameTotalKost,AmountPaidUDZ1,AmountPaidUDZ2,TotalAmountPaid,TotalAmountToPay")] ZoneGameReceipt zoneGameReceipt)
        {
            if (id != zoneGameReceipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationDbContext = _context.ZoneGameReceipt
                 .Include(z => z.ReceiptCategory)
                .Include(z => z.ReceiptStatus)
                .Include(z => z.ReceiptType)
                .Include(z => z.ZoneGame)
                .Include(z => z.ZoneGame.Arena)
                .Include(z => z.ZoneGame.UDZ1)
                .Include(z => z.ZoneGame.UDZ2)
                .Include(z => z.ZoneGame.Zone1)
                .Include(z => z.ZoneGame.Zone2)
                .Include(z => z.ZoneGame.HomeTeam1)
                .Include(z => z.ZoneGame.HomeTeam2)
                .Include(z => z.ZoneGame.AwayTeam1)
                .Include(z => z.ZoneGame.AwayTeam2)
                .Include(z => z.ZoneGame.GameCategory);
                    zoneGameReceipt.UDZ1TotalFee = zoneGameReceipt.UDZ1Fee + zoneGameReceipt.UDZ1Alowens + zoneGameReceipt.UDZ1Other + zoneGameReceipt.UDZ1TravelKost + zoneGameReceipt.UDZ1LateGameKost;
                    zoneGameReceipt.UDZ2TotalFee = zoneGameReceipt.UDZ2Fee + zoneGameReceipt.UDZ2Alowens + zoneGameReceipt.UDZ2Other + zoneGameReceipt.UDZ2TravelKost + zoneGameReceipt.UDZ2LateGameKost;

                    _context.Update(zoneGameReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoneGameReceiptExists(zoneGameReceipt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListZoneGameReceipts));
            }
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", zoneGameReceipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", zoneGameReceipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", zoneGameReceipt.ReceiptTypeId);
            ViewData["ZoneGameId"] = new SelectList(_context.ZoneGame, "Id", "ZoneGameName", zoneGameReceipt.ZoneGameId);
            return View(zoneGameReceipt);
        }

        // GET: ZoneGameReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoneGameReceipt = await _context.ZoneGameReceipt
                .Include(z => z.ReceiptCategory)
                .Include(z => z.ReceiptStatus)
                .Include(z => z.ReceiptType)
                .Include(z => z.ZoneGame)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoneGameReceipt == null)
            {
                return NotFound();
            }

            return View(zoneGameReceipt);
        }

        // POST: ZoneGameReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zoneGameReceipt = await _context.ZoneGameReceipt.FindAsync(id);
            _context.ZoneGameReceipt.Remove(zoneGameReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListZoneGameReceipts));
        }

        private bool ZoneGameReceiptExists(int id)
        {
            return _context.ZoneGameReceipt.Any(e => e.Id == id);
        }
    }
}

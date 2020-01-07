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
    public class ReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Receipt !
        public async Task<IActionResult> Receipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: VetsReceipt !
        public async Task<IActionResult> VetsReceipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }


        //Lists Receipts with status Created !
        public IActionResult ListReceipts()
        {
            var receiptsViewModel = new ReceiptsViewModel()
            {
                Receipts = _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType).Where(r => r.ReceiptStatusId == 1).ToList()
            };
            return View(receiptsViewModel);
        }

        //Lists Receipts with status DueToPay !
        public IActionResult ListReceiptsDueToPay()
        {
            var receiptsViewModel = new ReceiptsViewModel()
            {
                Receipts = _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType).Where(r => r.ReceiptStatusId == 2).ToList()
            };
            return View(receiptsViewModel);
        }

        //Lists Receipts with status Paid !
        public IActionResult ListReceiptsPaid()
        {
            var receiptsViewModel = new ReceiptsViewModel()
            {
                Receipts = _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType).Where(r => r.ReceiptStatusId == 3).ToList()
            };
            return View(receiptsViewModel);
        }

        //Lists Receipts with status Paid !
        public IActionResult ListReceiptsArchived()
        {
            var receiptsViewModel = new ReceiptsViewModel()
            {
                Receipts = _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType).Where(r => r.ReceiptStatusId == 5).ToList()
            };
            return View(receiptsViewModel);
        }

        public IActionResult ListCupGameReceipts()
        {
            var receiptsViewModel = new ReceiptsViewModel()
            {
                Receipts = _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType)
                .Include(r => r.ReceiptCategory).Where(r => r.ReceiptCategoryId == 3).ToList()
            };
            return View(receiptsViewModel);
        }
        public IActionResult ListVetsGameReceipts()
        {
            var receiptsViewModel = new ReceiptsViewModel()
            {
                Receipts = _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType)
                .Include(r => r.ReceiptCategory).Where(r => r.Game.GameCategoryId == 11).ToList()
            };
            return View(receiptsViewModel);
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Receipts/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "TSMNumber");
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName");
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName");
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName");
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,GameId,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1Other,HD1TotalFee,HD2Fee,HD2TravelKost,HD2Alowens,HD2LateGameKost,HD2Other,HD2TotalFee,LD1Fee,LD1TravelKost,LD1Alowens,LD1LateGameKost,LD1Other,LD1TotalFee,LD2Fee,LD2TravelKost,LD2Alowens,LD2LateGameKost,LD2Other,LD2TotalFee,GameTotalKost,AmountPaidHD1,AmountPaidHD2,AmountPaidLD1,AmountPaidLD2,TotalAmountPaid,TotalAmountToPay")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                var applicationDbContext = _context.Receipt
                 .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType);
                receipt.HD1TotalFee = receipt.HD1Fee + receipt.HD1TravelKost + receipt.HD1Alowens + receipt.HD1LateGameKost + receipt.HD1Other;
                receipt.HD2TotalFee = receipt.HD2Fee + receipt.HD2TravelKost + receipt.HD2Alowens + receipt.HD2LateGameKost + receipt.HD2Other;
                receipt.LD1TotalFee = receipt.LD1Fee + receipt.LD1TravelKost + receipt.LD1Alowens + receipt.LD1LateGameKost + receipt.LD1Other;
                receipt.LD2TotalFee = receipt.LD2Fee + receipt.LD2TravelKost + receipt.LD2Alowens + receipt.LD2LateGameKost + receipt.LD2Other;
                receipt.GameTotalKost = receipt.HD1TotalFee + receipt.HD2TotalFee + receipt.LD1TotalFee + receipt.LD2TotalFee;

                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListReceipts));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "TSMNumber", receipt.GameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", receipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", receipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", receipt.ReceiptTypeId);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "TSMNumber", receipt.GameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", receipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", receipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", receipt.ReceiptTypeId);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptCategoryId,ReceiptStatusId,ReceiptTypeId,GameId,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1Other,HD1TotalFee,HD2Fee,HD2TravelKost,HD2Alowens,HD2LateGameKost,HD2Other,HD2TotalFee,LD1Fee,LD1TravelKost,LD1Alowens,LD1LateGameKost,LD1Other,LD1TotalFee,LD2Fee,LD2TravelKost,LD2Alowens,LD2LateGameKost,LD2Other,LD2TotalFee,GameTotalKost,AmountPaidHD1,AmountPaidHD2,AmountPaidLD1,AmountPaidLD2,TotalAmountPaid,TotalAmountToPay")] Receipt receipt)
        {
            if (id != receipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationDbContext = _context.Receipt
                    .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType);
                    receipt.HD1TotalFee = receipt.HD1Fee + receipt.HD1TravelKost + receipt.HD1Alowens + receipt.HD1LateGameKost + receipt.HD1Other;
                    receipt.HD2TotalFee = receipt.HD2Fee + receipt.HD2TravelKost + receipt.HD2Alowens + receipt.HD2LateGameKost + receipt.HD2Other;
                    receipt.LD1TotalFee = receipt.LD1Fee + receipt.LD1TravelKost + receipt.LD1Alowens + receipt.LD1LateGameKost + receipt.LD1Other;
                    receipt.LD2TotalFee = receipt.LD2Fee + receipt.LD2TravelKost + receipt.LD2Alowens + receipt.LD2LateGameKost + receipt.LD2Other;
                    receipt.GameTotalKost = receipt.HD1TotalFee + receipt.HD2TotalFee + receipt.LD1TotalFee + receipt.LD2TotalFee;

                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListReceipts));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "TSMNumber", receipt.GameId);
            ViewData["ReceiptCategoryId"] = new SelectList(_context.ReceiptCategory, "Id", "ReceiptCategoryName", receipt.ReceiptCategoryId);
            ViewData["ReceiptStatusId"] = new SelectList(_context.ReceiptStatus, "Id", "ReceiptStatusName", receipt.ReceiptStatusId);
            ViewData["ReceiptTypeId"] = new SelectList(_context.ReceiptType, "Id", "ReceiptTypeName", receipt.ReceiptTypeId);
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
               .Include(r => r.Game)
                .Include(r => r.Game.HD1)
                .Include(r => r.Game.HD2)
                .Include(r => r.Game.LD1)
                .Include(r => r.Game.LD2)
                .Include(r => r.Game.HomeTeam)
                .Include(r => r.Game.AwayTeam)
                .Include(r => r.Game.Arena)
                .Include(r => r.Game.GameCategory)
                .Include(r => r.ReceiptCategory)
                .Include(r => r.ReceiptStatus)
                .Include(r => r.ReceiptType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListReceipts));
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipt.Any(e => e.Id == id);
        }
    }
}

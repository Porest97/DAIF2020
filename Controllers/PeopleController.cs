using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Data;
using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;

namespace DAIF2020.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Person
                .Include(p => p.Club)
                .Include(p => p.District)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Club)
                .Include(p => p.District)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id");
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id");
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "Id");
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "Id");
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "Id");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonRoleId,PersonStatusId,PersonTypeId,ClubId,DistrictId,FirstName,LastName,StreetAddress,ZipCode,City,Country,Ssn,PhoneNumber1,PhoneNumber2,Email,SwishNumber,BankAccount,BankName")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id", person.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", person.DistrictId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "Id", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "Id", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "Id", person.PersonTypeId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id", person.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", person.DistrictId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "Id", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "Id", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "Id", person.PersonTypeId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonRoleId,PersonStatusId,PersonTypeId,ClubId,DistrictId,FirstName,LastName,StreetAddress,ZipCode,City,Country,Ssn,PhoneNumber1,PhoneNumber2,Email,SwishNumber,BankAccount,BankName")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "Id", person.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", person.DistrictId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "Id", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "Id", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "Id", person.PersonTypeId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Club)
                .Include(p => p.District)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}

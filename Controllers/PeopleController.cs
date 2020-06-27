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
using DAIF2020.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DAIF2020.Controllers
{
    [Authorize]
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

        public IActionResult ListPeople()
        {
            var peopleViewModel = new PeopleViewModel()
            {
                People = _context.Person
                .Include(p => p.Club)
                .Include(p => p.District)
                .Include(p => p.PersonRole)
                .Include(p => p.PersonStatus)
                .Include(p => p.PersonType)
                .ToList()
            };
            return View(peopleViewModel);
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
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName");
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName");
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName");
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName");
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName");
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
                return RedirectToAction(nameof(ListPeople));
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", person.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", person.DistrictId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName", person.PersonTypeId);
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
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", person.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", person.DistrictId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName", person.PersonTypeId);
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
                return RedirectToAction(nameof(ListPeople));
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", person.ClubId);
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "DistrictName", person.DistrictId);
            ViewData["PersonRoleId"] = new SelectList(_context.Set<PersonRole>(), "Id", "PersonRoleName", person.PersonRoleId);
            ViewData["PersonStatusId"] = new SelectList(_context.Set<PersonStatus>(), "Id", "PersonStatusName", person.PersonStatusId);
            ViewData["PersonTypeId"] = new SelectList(_context.Set<PersonType>(), "Id", "PersonTypeName", person.PersonTypeId);
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
            return RedirectToAction(nameof(ListPeople));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}

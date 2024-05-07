using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RentalDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalDatas/Home
        public async Task<IActionResult> Home()
        {
            return View(await _context.RentalData.ToListAsync());
        }
        // GET: RentalDatas
        public async Task<IActionResult> Index1()
        {
            return View(await _context.RentalData.ToListAsync());
        }

        public async Task<IActionResult> Data()
        {
            return View(await _context.RentalData.ToListAsync());
        }

        //Get: ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        //Payment Page
        public async Task<IActionResult> Payment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalData == null)
            {
                return NotFound();
            }

            return View();
        }





        //Tags

        public async Task<IActionResult> Bike()
        {
            return
                View("Index1", await _context.RentalData.Where(j => j.Tags.Contains("Bike")).ToListAsync());

        }
        public async Task<IActionResult> Car()
        {
            return
                View("Index1", await _context.RentalData.Where(j => j.Tags.Contains("Car")).ToListAsync());

        }

        public async Task<IActionResult> Laptop()
        {
            return
                View("Index1", await _context.RentalData.Where(j => j.Tags.Contains("Laptop")).ToListAsync());

        }


        //use
        [Authorize]
        public async Task<IActionResult> Use(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalData == null)
            {
                return NotFound();
            }

            return View(rentalData);
        }

        [HttpPost, ActionName("Use")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UseConfirmed(int id)
        {
            var rentalData = await _context.RentalData.FindAsync(id);
            if (rentalData != null)
            {
                _context.RentalData.Remove(rentalData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index1));
        }

        //Get: ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return
                View("Index1", await _context.RentalData.Where(j => j.Tags.Contains(SearchPhrase)).ToListAsync());

        }
        // GET: RentalDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalData == null)
            {
                return NotFound();
            }

            return View(rentalData);
        }

        // GET: RentalDatas/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Prize,Tags")] RentalData rentalData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index1));
            }
            return View(rentalData);
        }
        [Authorize]
        // GET: RentalDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData.FindAsync(id);
            if (rentalData == null)
            {
                return NotFound();
            }
            return View(rentalData);
        }

        // POST: RentalDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Prize,Tags")] RentalData rentalData)
        {
            if (id != rentalData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalDataExists(rentalData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index1));
            }
            return View(rentalData);
        }
        [Authorize]
        // GET: RentalDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalData == null)
            {
                return NotFound();
            }

            return View(rentalData);
        }

        // POST: RentalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalData = await _context.RentalData.FindAsync(id);
            if (rentalData != null)
            {
                _context.RentalData.Remove(rentalData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index1));
        }

        private bool RentalDataExists(int id)
        {
            return _context.RentalData.Any(e => e.Id == id);
        }
    }
}

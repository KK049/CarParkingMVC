using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarParkingMVC.Data;
using CarParkingMVC.Models;

namespace CarParkingMVC.Controllers
{
    public class BookingCarsController : Controller
    {
        private readonly CarParkingMVCContext _context;

        public BookingCarsController(CarParkingMVCContext context)
        {
            _context = context;
        }

        // GET: BookingCars
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookingCars.ToListAsync());
        }

        // GET: BookingCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingCars = await _context.BookingCars
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookingCars == null)
            {
                return NotFound();
            }

            return View(bookingCars);
        }

        // GET: BookingCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Contact,CarModel,BookingDate")] BookingCars bookingCars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingCars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingCars);
        }

        // GET: BookingCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingCars = await _context.BookingCars.FindAsync(id);
            if (bookingCars == null)
            {
                return NotFound();
            }
            return View(bookingCars);
        }

        // POST: BookingCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Contact,CarModel,BookingDate")] BookingCars bookingCars)
        {
            if (id != bookingCars.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingCars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingCarsExists(bookingCars.id))
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
            return View(bookingCars);
        }

        // GET: BookingCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingCars = await _context.BookingCars
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookingCars == null)
            {
                return NotFound();
            }

            return View(bookingCars);
        }

        // POST: BookingCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingCars = await _context.BookingCars.FindAsync(id);
            _context.BookingCars.Remove(bookingCars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingCarsExists(int id)
        {
            return _context.BookingCars.Any(e => e.id == id);
        }
    }
}

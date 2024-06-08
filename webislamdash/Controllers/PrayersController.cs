using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webislamdash.Data;
using webislamdash.Models;

namespace webislamdash.Controllers
{
    public class PrayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prayers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prayer.ToListAsync());
        }

        // GET: Prayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayer
                .FirstOrDefaultAsync(m => m.PrayerId == id);
            if (prayer == null)
            {
                return NotFound();
            }

            return View(prayer);
        }

        // GET: Prayers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prayers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrayerId,PrayerName,PrayerTime,PrayerDate,PrayerLocation")] Prayer prayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayer);
        }

        // GET: Prayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayer.FindAsync(id);
            if (prayer == null)
            {
                return NotFound();
            }
            return View(prayer);
        }

        // POST: Prayers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrayerId,PrayerName,PrayerTime,PrayerDate,PrayerLocation")] Prayer prayer)
        {
            if (id != prayer.PrayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerExists(prayer.PrayerId))
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
            return View(prayer);
        }

        // GET: Prayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayer
                .FirstOrDefaultAsync(m => m.PrayerId == id);
            if (prayer == null)
            {
                return NotFound();
            }

            return View(prayer);
        }

        // POST: Prayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prayer = await _context.Prayer.FindAsync(id);
            if (prayer != null)
            {
                _context.Prayer.Remove(prayer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerExists(int id)
        {
            return _context.Prayer.Any(e => e.PrayerId == id);
        }
    }
}

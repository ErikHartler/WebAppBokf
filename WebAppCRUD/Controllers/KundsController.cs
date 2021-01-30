using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers
{
    public class KundsController : Controller
    {
        private readonly BokforingContext _context;

        public KundsController(BokforingContext context)
        {
            _context = context;
        }

        // GET: Kunds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kund.ToListAsync());
        }

        // GET: Kunds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kund = await _context.Kund
                .FirstOrDefaultAsync(m => m.Kundnummer == id);
            if (kund == null)
            {
                return NotFound();
            }

            return View(kund);
        }

        // GET: Kunds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kunds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kundnummer,Kundnamn,Box,Postnummer,Ort,KontPersFornamn,KontPersEfternamn,Forfallodagar,Telefon,Telefax,Kommentar,Villkor,Ibkredit")] Kund kund)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kund);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kund);
        }

        // GET: Kunds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kund = await _context.Kund.FindAsync(id);
            if (kund == null)
            {
                return NotFound();
            }
            return View(kund);
        }

        // POST: Kunds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kundnummer,Kundnamn,Box,Postnummer,Ort,KontPersFornamn,KontPersEfternamn,Forfallodagar,Telefon,Telefax,Kommentar,Villkor,Ibkredit")] Kund kund)
        {
            if (id != kund.Kundnummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kund);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KundExists(kund.Kundnummer))
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
            return View(kund);
        }

        // GET: Kunds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kund = await _context.Kund
                .FirstOrDefaultAsync(m => m.Kundnummer == id);
            if (kund == null)
            {
                return NotFound();
            }

            return View(kund);
        }

        // POST: Kunds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kund = await _context.Kund.FindAsync(id);
            _context.Kund.Remove(kund);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KundExists(int id)
        {
            return _context.Kund.Any(e => e.Kundnummer == id);
        }
    }
}

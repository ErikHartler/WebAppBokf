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
    public class KontaktpersonKundsController : Controller
    {
        private readonly BokforingContext _context;

        public KontaktpersonKundsController(BokforingContext context)
        {
            _context = context;
        }

        // GET: KontaktpersonKunds
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.KontaktpersonKund.Include(k => k.KundnummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: KontaktpersonKunds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontaktpersonKund = await _context.KontaktpersonKund
                .Include(k => k.KundnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontaktpersonKund == null)
            {
                return NotFound();
            }

            return View(kontaktpersonKund);
        }

        // GET: KontaktpersonKunds/Create
        public IActionResult Create()
        {
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer");
            return View();
        }

        // POST: KontaktpersonKunds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kundnummer,Radnummer,Fornamn,Efternamn,TelefonDirekt,TelefonHem,TelefonMobil,Id")] KontaktpersonKund kontaktpersonKund)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontaktpersonKund);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", kontaktpersonKund.Kundnummer);
            return View(kontaktpersonKund);
        }

        // GET: KontaktpersonKunds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontaktpersonKund = await _context.KontaktpersonKund.FindAsync(id);
            if (kontaktpersonKund == null)
            {
                return NotFound();
            }
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", kontaktpersonKund.Kundnummer);
            return View(kontaktpersonKund);
        }

        // POST: KontaktpersonKunds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kundnummer,Radnummer,Fornamn,Efternamn,TelefonDirekt,TelefonHem,TelefonMobil,Id")] KontaktpersonKund kontaktpersonKund)
        {
            if (id != kontaktpersonKund.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontaktpersonKund);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontaktpersonKundExists(kontaktpersonKund.Id))
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
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", kontaktpersonKund.Kundnummer);
            return View(kontaktpersonKund);
        }

        // GET: KontaktpersonKunds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontaktpersonKund = await _context.KontaktpersonKund
                .Include(k => k.KundnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontaktpersonKund == null)
            {
                return NotFound();
            }

            return View(kontaktpersonKund);
        }

        // POST: KontaktpersonKunds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontaktpersonKund = await _context.KontaktpersonKund.FindAsync(id);
            _context.KontaktpersonKund.Remove(kontaktpersonKund);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontaktpersonKundExists(int id)
        {
            return _context.KontaktpersonKund.Any(e => e.Id == id);
        }
    }
}

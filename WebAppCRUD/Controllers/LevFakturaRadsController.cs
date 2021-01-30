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
    public class LevFakturaRadsController : Controller
    {
        private readonly BokforingContext _context;

        public LevFakturaRadsController(BokforingContext context)
        {
            _context = context;
        }

        // GET: LevFakturaRads
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.LevFakturaRad.Include(l => l.LevFakturanummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: LevFakturaRads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levFakturaRad = await _context.LevFakturaRad
                .Include(l => l.LevFakturanummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levFakturaRad == null)
            {
                return NotFound();
            }

            return View(levFakturaRad);
        }

        // GET: LevFakturaRads/Create
        public IActionResult Create()
        {
            ViewData["LevFakturanummer"] = new SelectList(_context.LevFaktura, "LevFakturanummer", "LevFakturanummer");
            return View();
        }

        // POST: LevFakturaRads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevFakturanummer,Radnummer,ProduktTjanst,Enhetspris,Enhet,SummaKr,Antal,Id")] LevFakturaRad levFakturaRad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levFakturaRad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LevFakturanummer"] = new SelectList(_context.LevFaktura, "LevFakturanummer", "LevFakturanummer", levFakturaRad.LevFakturanummer);
            return View(levFakturaRad);
        }

        // GET: LevFakturaRads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levFakturaRad = await _context.LevFakturaRad.FindAsync(id);
            if (levFakturaRad == null)
            {
                return NotFound();
            }
            ViewData["LevFakturanummer"] = new SelectList(_context.LevFaktura, "LevFakturanummer", "LevFakturanummer", levFakturaRad.LevFakturanummer);
            return View(levFakturaRad);
        }

        // POST: LevFakturaRads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevFakturanummer,Radnummer,ProduktTjanst,Enhetspris,Enhet,SummaKr,Antal,Id")] LevFakturaRad levFakturaRad)
        {
            if (id != levFakturaRad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levFakturaRad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevFakturaRadExists(levFakturaRad.Id))
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
            ViewData["LevFakturanummer"] = new SelectList(_context.LevFaktura, "LevFakturanummer", "LevFakturanummer", levFakturaRad.LevFakturanummer);
            return View(levFakturaRad);
        }

        // GET: LevFakturaRads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levFakturaRad = await _context.LevFakturaRad
                .Include(l => l.LevFakturanummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levFakturaRad == null)
            {
                return NotFound();
            }

            return View(levFakturaRad);
        }

        // POST: LevFakturaRads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var levFakturaRad = await _context.LevFakturaRad.FindAsync(id);
            _context.LevFakturaRad.Remove(levFakturaRad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevFakturaRadExists(int id)
        {
            return _context.LevFakturaRad.Any(e => e.Id == id);
        }
    }
}

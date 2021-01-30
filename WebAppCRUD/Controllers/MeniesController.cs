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
    public class MeniesController : Controller
    {
        private readonly BokforingContext _context;

        public MeniesController(BokforingContext context)
        {
            _context = context;
        }

        // GET: Menies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meny.ToListAsync());
        }

        // GET: Menies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meny = await _context.Meny
                .FirstOrDefaultAsync(m => m.Meny1 == id);
            if (meny == null)
            {
                return NotFound();
            }

            return View(meny);
        }

        // GET: Menies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Meny1,Beskrivning,Presentationsordning")] Meny meny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meny);
        }

        // GET: Menies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meny = await _context.Meny.FindAsync(id);
            if (meny == null)
            {
                return NotFound();
            }
            return View(meny);
        }

        // POST: Menies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Meny1,Beskrivning,Presentationsordning")] Meny meny)
        {
            if (id != meny.Meny1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenyExists(meny.Meny1))
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
            return View(meny);
        }

        // GET: Menies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meny = await _context.Meny
                .FirstOrDefaultAsync(m => m.Meny1 == id);
            if (meny == null)
            {
                return NotFound();
            }

            return View(meny);
        }

        // POST: Menies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var meny = await _context.Meny.FindAsync(id);
            _context.Meny.Remove(meny);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenyExists(string id)
        {
            return _context.Meny.Any(e => e.Meny1 == id);
        }
    }
}

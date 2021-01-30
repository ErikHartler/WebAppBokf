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
    public class KostnadsbararesController : Controller
    {
        private readonly BokforingContext _context;

        public KostnadsbararesController(BokforingContext context)
        {
            _context = context;
        }

        // GET: Kostnadsbarares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kostnadsbarare.ToListAsync());
        }

        // GET: Kostnadsbarares/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kostnadsbarare = await _context.Kostnadsbarare
                .FirstOrDefaultAsync(m => m.Kostnadsbarare1 == id);
            if (kostnadsbarare == null)
            {
                return NotFound();
            }

            return View(kostnadsbarare);
        }

        // GET: Kostnadsbarares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kostnadsbarares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kostnadsbarare1,Beskrivning")] Kostnadsbarare kostnadsbarare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kostnadsbarare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kostnadsbarare);
        }

        // GET: Kostnadsbarares/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kostnadsbarare = await _context.Kostnadsbarare.FindAsync(id);
            if (kostnadsbarare == null)
            {
                return NotFound();
            }
            return View(kostnadsbarare);
        }

        // POST: Kostnadsbarares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Kostnadsbarare1,Beskrivning")] Kostnadsbarare kostnadsbarare)
        {
            if (id != kostnadsbarare.Kostnadsbarare1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kostnadsbarare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KostnadsbarareExists(kostnadsbarare.Kostnadsbarare1))
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
            return View(kostnadsbarare);
        }

        // GET: Kostnadsbarares/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kostnadsbarare = await _context.Kostnadsbarare
                .FirstOrDefaultAsync(m => m.Kostnadsbarare1 == id);
            if (kostnadsbarare == null)
            {
                return NotFound();
            }

            return View(kostnadsbarare);
        }

        // POST: Kostnadsbarares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kostnadsbarare = await _context.Kostnadsbarare.FindAsync(id);
            _context.Kostnadsbarare.Remove(kostnadsbarare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KostnadsbarareExists(string id)
        {
            return _context.Kostnadsbarare.Any(e => e.Kostnadsbarare1 == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Models;

namespace WebAppCRUD.Views
{
    public class EnhetsController : Controller
    {
        private readonly BokforingContext _context;

        public EnhetsController(BokforingContext context)
        {
            _context = context;
        }

        // GET: Enhets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enhet.ToListAsync());
        }

        // GET: Enhets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enhet = await _context.Enhet
                .FirstOrDefaultAsync(m => m.Enhet1 == id);
            if (enhet == null)
            {
                return NotFound();
            }

            return View(enhet);
        }

        // GET: Enhets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enhets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Enhet1,Beskrivning")] Enhet enhet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enhet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enhet);
        }

        // GET: Enhets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enhet = await _context.Enhet.FindAsync(id);
            if (enhet == null)
            {
                return NotFound();
            }
            return View(enhet);
        }

        // POST: Enhets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Enhet1,Beskrivning")] Enhet enhet)
        {
            if (id != enhet.Enhet1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enhet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnhetExists(enhet.Enhet1))
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
            return View(enhet);
        }

        // GET: Enhets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enhet = await _context.Enhet
                .FirstOrDefaultAsync(m => m.Enhet1 == id);
            if (enhet == null)
            {
                return NotFound();
            }

            return View(enhet);
        }

        // POST: Enhets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var enhet = await _context.Enhet.FindAsync(id);
            _context.Enhet.Remove(enhet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnhetExists(string id)
        {
            return _context.Enhet.Any(e => e.Enhet1 == id);
        }
    }
}

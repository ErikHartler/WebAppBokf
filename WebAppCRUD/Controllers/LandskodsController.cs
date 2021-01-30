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
    public class LandskodsController : Controller
    {
        private readonly BokforingContext _context;

        public LandskodsController(BokforingContext context)
        {
            _context = context;
        }

        // GET: Landskods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Landskod.ToListAsync());
        }

        // GET: Landskods/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landskod = await _context.Landskod
                .FirstOrDefaultAsync(m => m.Landskod1 == id);
            if (landskod == null)
            {
                return NotFound();
            }

            return View(landskod);
        }

        // GET: Landskods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Landskods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Landskod1,Land")] Landskod landskod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landskod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(landskod);
        }

        // GET: Landskods/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landskod = await _context.Landskod.FindAsync(id);
            if (landskod == null)
            {
                return NotFound();
            }
            return View(landskod);
        }

        // POST: Landskods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Landskod1,Land")] Landskod landskod)
        {
            if (id != landskod.Landskod1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landskod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandskodExists(landskod.Landskod1))
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
            return View(landskod);
        }

        // GET: Landskods/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landskod = await _context.Landskod
                .FirstOrDefaultAsync(m => m.Landskod1 == id);
            if (landskod == null)
            {
                return NotFound();
            }

            return View(landskod);
        }

        // POST: Landskods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var landskod = await _context.Landskod.FindAsync(id);
            _context.Landskod.Remove(landskod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandskodExists(string id)
        {
            return _context.Landskod.Any(e => e.Landskod1 == id);
        }
    }
}

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
    public class MallTransaktionersController : Controller
    {
        private readonly BokforingContext _context;

        public MallTransaktionersController(BokforingContext context)
        {
            _context = context;
        }

        // GET: MallTransaktioners
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.MallTransaktioner.Include(m => m.KortkodNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: MallTransaktioners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallTransaktioner = await _context.MallTransaktioner
                .Include(m => m.KortkodNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mallTransaktioner == null)
            {
                return NotFound();
            }

            return View(mallTransaktioner);
        }

        // GET: MallTransaktioners/Create
        public IActionResult Create()
        {
            ViewData["Kortkod"] = new SelectList(_context.MallVerifikat, "Kortkod", "Kortkod");
            return View();
        }

        // POST: MallTransaktioners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kortkod,Radnr,DebetProc,KreditProc,Konto,Kostnadsbarare,Id")] MallTransaktioner mallTransaktioner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mallTransaktioner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Kortkod"] = new SelectList(_context.MallVerifikat, "Kortkod", "Kortkod", mallTransaktioner.Kortkod);
            return View(mallTransaktioner);
        }

        // GET: MallTransaktioners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallTransaktioner = await _context.MallTransaktioner.FindAsync(id);
            if (mallTransaktioner == null)
            {
                return NotFound();
            }
            ViewData["Kortkod"] = new SelectList(_context.MallVerifikat, "Kortkod", "Kortkod", mallTransaktioner.Kortkod);
            return View(mallTransaktioner);
        }

        // POST: MallTransaktioners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kortkod,Radnr,DebetProc,KreditProc,Konto,Kostnadsbarare,Id")] MallTransaktioner mallTransaktioner)
        {
            if (id != mallTransaktioner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mallTransaktioner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MallTransaktionerExists(mallTransaktioner.Id))
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
            ViewData["Kortkod"] = new SelectList(_context.MallVerifikat, "Kortkod", "Kortkod", mallTransaktioner.Kortkod);
            return View(mallTransaktioner);
        }

        // GET: MallTransaktioners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallTransaktioner = await _context.MallTransaktioner
                .Include(m => m.KortkodNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mallTransaktioner == null)
            {
                return NotFound();
            }

            return View(mallTransaktioner);
        }

        // POST: MallTransaktioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mallTransaktioner = await _context.MallTransaktioner.FindAsync(id);
            _context.MallTransaktioner.Remove(mallTransaktioner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MallTransaktionerExists(int id)
        {
            return _context.MallTransaktioner.Any(e => e.Id == id);
        }
    }
}

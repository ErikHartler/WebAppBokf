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
    public class MallVerifikatsController : Controller
    {
        private readonly BokforingContext _context;

        public MallVerifikatsController(BokforingContext context)
        {
            _context = context;
        }

        // GET: MallVerifikats
        public async Task<IActionResult> Index()
        {
            return View(await _context.MallVerifikat.ToListAsync());
        }

        // GET: MallVerifikats/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallVerifikat = await _context.MallVerifikat
                .FirstOrDefaultAsync(m => m.Kortkod == id);
            if (mallVerifikat == null)
            {
                return NotFound();
            }

            return View(mallVerifikat);
        }

        // GET: MallVerifikats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MallVerifikats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kortkod,Konto100Proc,OmDebet100Proc,Anvands,Frekvens,Belopp100Proc,OmKundnrSpec")] MallVerifikat mallVerifikat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mallVerifikat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mallVerifikat);
        }

        // GET: MallVerifikats/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallVerifikat = await _context.MallVerifikat.FindAsync(id);
            if (mallVerifikat == null)
            {
                return NotFound();
            }
            return View(mallVerifikat);
        }

        // POST: MallVerifikats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Kortkod,Konto100Proc,OmDebet100Proc,Anvands,Frekvens,Belopp100Proc,OmKundnrSpec")] MallVerifikat mallVerifikat)
        {
            if (id != mallVerifikat.Kortkod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mallVerifikat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MallVerifikatExists(mallVerifikat.Kortkod))
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
            return View(mallVerifikat);
        }

        // GET: MallVerifikats/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mallVerifikat = await _context.MallVerifikat
                .FirstOrDefaultAsync(m => m.Kortkod == id);
            if (mallVerifikat == null)
            {
                return NotFound();
            }

            return View(mallVerifikat);
        }

        // POST: MallVerifikats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mallVerifikat = await _context.MallVerifikat.FindAsync(id);
            _context.MallVerifikat.Remove(mallVerifikat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MallVerifikatExists(string id)
        {
            return _context.MallVerifikat.Any(e => e.Kortkod == id);
        }
    }
}

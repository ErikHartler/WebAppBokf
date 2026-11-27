using System.Linq;
using System.Threading.Tasks;
using EFData;
using EfLibrary.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppCRUD.Controllers
{
    public class BetalsattsController(BokforingContext context) : AbstractController(context)
    {
        


        // GET: Betalsatts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Betalsatt.ToListAsync());
        }

        // GET: Betalsatts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var betalsatt = await _context.Betalsatt
                .FirstOrDefaultAsync(m => m.Betalsatt1 == id);
            if (betalsatt == null)
            {
                return NotFound();
            }

            return View(betalsatt);
        }

        // GET: Betalsatts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Betalsatts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Betalsatt1,Beskrivning")] Betalsatt betalsatt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(betalsatt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(betalsatt);
        }

        // GET: Betalsatts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var betalsatt = await _context.Betalsatt.FindAsync(id);
            if (betalsatt == null)
            {
                return NotFound();
            }
            return View(betalsatt);
        }

        // POST: Betalsatts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Betalsatt1,Beskrivning")] Betalsatt betalsatt)
        {
            if (id != betalsatt.Betalsatt1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(betalsatt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BetalsattExists(betalsatt.Betalsatt1))
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
            return View(betalsatt);
        }

        // GET: Betalsatts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var betalsatt = await _context.Betalsatt
                .FirstOrDefaultAsync(m => m.Betalsatt1 == id);
            if (betalsatt == null)
            {
                return NotFound();
            }

            return View(betalsatt);
        }

        // POST: Betalsatts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var betalsatt = await _context.Betalsatt.FindAsync(id);
            _context.Betalsatt.Remove(betalsatt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BetalsattExists(string id)
        {
            return _context.Betalsatt.Any(e => e.Betalsatt1 == id);
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class TransaktionsController(BokforingContext context) : AbstractController(context)
    {
        //private readonly BokforingContext _context;


        // GET: Transaktions
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.Transaktion.Include(t => t.VerifikationNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: Transaktions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaktion = await _context.Transaktion
                .Include(t => t.VerifikationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaktion == null)
            {
                return NotFound();
            }

            return View(transaktion);
        }

        // GET: Transaktions/Create
        public IActionResult Create()
        {
            ViewData["Verifikation"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1");
            return View();
        }

        // POST: Transaktions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Verifikation,Radnummer,DebetKr,Konto,Kostnadsbarare,KreditKr,Id")] Transaktion transaktion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaktion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Verifikation"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1", transaktion.Verifikation);
            return View(transaktion);
        }

        // GET: Transaktions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaktion = await _context.Transaktion.FindAsync(id);
            if (transaktion == null)
            {
                return NotFound();
            }
            ViewData["Verifikation"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1", transaktion.Verifikation);
            return View(transaktion);
        }

        // POST: Transaktions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Verifikation,Radnummer,DebetKr,Konto,Kostnadsbarare,KreditKr,Id")] Transaktion transaktion)
        {
            if (id != transaktion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaktion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaktionExists(transaktion.Id))
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
            ViewData["Verifikation"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1", transaktion.Verifikation);
            return View(transaktion);
        }

        // GET: Transaktions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaktion = await _context.Transaktion
                .Include(t => t.VerifikationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaktion == null)
            {
                return NotFound();
            }

            return View(transaktion);
        }

        // POST: Transaktions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaktion = await _context.Transaktion.FindAsync(id);
            _context.Transaktion.Remove(transaktion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaktionExists(int id)
        {
            return _context.Transaktion.Any(e => e.Id == id);
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class VerifikationsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public VerifikationsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Verifikations
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.Verifikation.Include(v => v.FakturanrNavigation).Include(v => v.KundnummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: Verifikations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verifikation = await _context.Verifikation
                .Include(v => v.FakturanrNavigation)
                .Include(v => v.KundnummerNavigation)
                .Include(v => v.Transaktions)
                .FirstOrDefaultAsync(m => m.Verifikation1 == id);
            if (verifikation == null)
            {
                return NotFound();
            }

            return View(verifikation);
        }

        // GET: Verifikations/Create
        public IActionResult Create()
        {
            ViewData["Fakturanr"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer");
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer");
            return View();
        }

        // POST: Verifikations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Verifikation1,Beskrivning,Transaktionsdatum,DebetKr,KreditKr,Bokforingsdatum,Kundnummer,Fakturanr")] Verifikation verifikation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verifikation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fakturanr"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer", verifikation.Fakturanr);
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", verifikation.Kundnummer);
            return View(verifikation);
        }

        // GET: Verifikations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var verifikation = await _context.Verifikation.FindAsync(id);
            var verifikation = await _context.Verifikation
               .Include(v => v.FakturanrNavigation)
               .Include(v => v.KundnummerNavigation)
               .Include(v => v.Transaktions)
               .FirstOrDefaultAsync(m => m.Verifikation1 == id);
            if (verifikation == null)
            {
                return NotFound();
            }
            ViewData["Fakturanr"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer", verifikation.Fakturanr);
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", verifikation.Kundnummer);
            return View(verifikation);
        }

        // POST: Verifikations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Verifikation1,Beskrivning,Transaktionsdatum,DebetKr,KreditKr,Bokforingsdatum,Kundnummer,Fakturanr")] Verifikation verifikation)
        {
            if (id != verifikation.Verifikation1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verifikation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerifikationExists(verifikation.Verifikation1))
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
            ViewData["Fakturanr"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer", verifikation.Fakturanr);
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", verifikation.Kundnummer);
            return View(verifikation);
        }

        // GET: Verifikations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verifikation = await _context.Verifikation
                .Include(v => v.FakturanrNavigation)
                .Include(v => v.KundnummerNavigation)
                .FirstOrDefaultAsync(m => m.Verifikation1 == id);
            if (verifikation == null)
            {
                return NotFound();
            }

            return View(verifikation);
        }

        // POST: Verifikations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verifikation = await _context.Verifikation.FindAsync(id);
            _context.Verifikation.Remove(verifikation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerifikationExists(int id)
        {
            return _context.Verifikation.Any(e => e.Verifikation1 == id);
        }
    }
}

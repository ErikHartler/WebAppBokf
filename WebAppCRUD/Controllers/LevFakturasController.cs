using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class LevFakturasController(BokforingContext context) : AbstractController(context)
    {
        //private readonly BokforingContext _context;


        // GET: LevFakturas
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.LevFaktura.Include(l => l.VerNrNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: LevFakturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levFaktura = await _context.LevFaktura
                .Include(l => l.VerNrNavigation)
                .FirstOrDefaultAsync(m => m.LevFakturanummer == id);
            if (levFaktura == null)
            {
                return NotFound();
            }

            return View(levFaktura);
        }

        // GET: LevFakturas/Create
        public IActionResult Create()
        {
            ViewData["VerNr"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1");
            return View();
        }

        // POST: LevFakturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevFakturanummer,Fakturadatum,Forfallodatum,Utskriftsdatum,Leverantörsnummer,BeloppExklMoms,MomsKr,BeloppInklMomsKr,BetaltKr,Betaldatum,VarReferens,ErRefForN,Kommentar,ErRefEfterN,Villkor,Momssats,VerNr,Godkann")] LevFaktura levFaktura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levFaktura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VerNr"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1", levFaktura.VerNr);
            return View(levFaktura);
        }

        // GET: LevFakturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levFaktura = await _context.LevFaktura.FindAsync(id);
            if (levFaktura == null)
            {
                return NotFound();
            }
            ViewData["VerNr"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1", levFaktura.VerNr);
            return View(levFaktura);
        }

        // POST: LevFakturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevFakturanummer,Fakturadatum,Forfallodatum,Utskriftsdatum,Leverantörsnummer,BeloppExklMoms,MomsKr,BeloppInklMomsKr,BetaltKr,Betaldatum,VarReferens,ErRefForN,Kommentar,ErRefEfterN,Villkor,Momssats,VerNr,Godkann")] LevFaktura levFaktura)
        {
            if (id != levFaktura.LevFakturanummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levFaktura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevFakturaExists(levFaktura.LevFakturanummer))
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
            ViewData["VerNr"] = new SelectList(_context.Verifikation, "Verifikation1", "Verifikation1", levFaktura.VerNr);
            return View(levFaktura);
        }

        // GET: LevFakturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levFaktura = await _context.LevFaktura
                .Include(l => l.VerNrNavigation)
                .FirstOrDefaultAsync(m => m.LevFakturanummer == id);
            if (levFaktura == null)
            {
                return NotFound();
            }

            return View(levFaktura);
        }

        // POST: LevFakturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var levFaktura = await _context.LevFaktura.FindAsync(id);
            _context.LevFaktura.Remove(levFaktura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevFakturaExists(int id)
        {
            return _context.LevFaktura.Any(e => e.LevFakturanummer == id);
        }
    }
}

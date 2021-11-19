using System.Linq;
using System.Threading.Tasks;
using EFData;
using EfLibrary.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebAppCRUD.Controllers
{
    public class FakturasController : AbstractController
    {
        //private readonly BokforingContext _context;

        public FakturasController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Fakturas
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.Faktura.Include(f => f.KundnummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: Fakturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Faktura
                .Include(f => f.KundnummerNavigation)
                .FirstOrDefaultAsync(m => m.Fakturanummer == id);
            if (faktura == null)
            {
                return NotFound();
            }

            return View(faktura);
        }

        // GET: Fakturas/Create
        public IActionResult Create()
        {
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer");
            return View();
        }

        // POST: Fakturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fakturanummer,Fakturadatum,Forfallodatum,Utskriftsdatum,Kundnummer,Kundnamn,Box,Postnummer,Ort,BeloppExklMoms,MomsKr,BeloppInklMomsKr,BetaltKr,Betaldatum,VarReferens,ErRefForN,Kommentar,ErRefEfterN,Villkor,Momssats,VerNr,Paminnelse1,Paminnelse2,Inkasso,UtestaendeFordr,Coadress,Land,Godkann,Projekt")] Faktura faktura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faktura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", faktura.Kundnummer);
            return View(faktura);
        }

        // GET: Fakturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Faktura.FindAsync(id);
            if (faktura == null)
            {
                return NotFound();
            }
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", faktura.Kundnummer);
            return View(faktura);
        }

        // POST: Fakturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fakturanummer,Fakturadatum,Forfallodatum,Utskriftsdatum,Kundnummer,Kundnamn,Box,Postnummer,Ort,BeloppExklMoms,MomsKr,BeloppInklMomsKr,BetaltKr,Betaldatum,VarReferens,ErRefForN,Kommentar,ErRefEfterN,Villkor,Momssats,VerNr,Paminnelse1,Paminnelse2,Inkasso,UtestaendeFordr,Coadress,Land,Godkann,Projekt")] Faktura faktura)
        {
            if (id != faktura.Fakturanummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faktura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakturaExists(faktura.Fakturanummer))
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
            ViewData["Kundnummer"] = new SelectList(_context.Kund, "Kundnummer", "Kundnummer", faktura.Kundnummer);
            return View(faktura);
        }

        // GET: Fakturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Faktura
                .Include(f => f.KundnummerNavigation)
                .FirstOrDefaultAsync(m => m.Fakturanummer == id);
            if (faktura == null)
            {
                return NotFound();
            }

            return View(faktura);
        }

        // POST: Fakturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faktura = await _context.Faktura.FindAsync(id);
            _context.Faktura.Remove(faktura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakturaExists(int id)
        {
            return _context.Faktura.Any(e => e.Fakturanummer == id);
        }
    }
}

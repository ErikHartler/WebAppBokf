using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class ProjektAktivitetsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public ProjektAktivitetsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: ProjektAktivitets
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.ProjektAktivitet.Include(p => p.LeverantorsnummerNavigation).Include(p => p.ProjektnummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: ProjektAktivitets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projektAktivitet = await _context.ProjektAktivitet
                .Include(p => p.LeverantorsnummerNavigation)
                .Include(p => p.ProjektnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projektAktivitet == null)
            {
                return NotFound();
            }

            return View(projektAktivitet);
        }

        // GET: ProjektAktivitets/Create
        public IActionResult Create()
        {
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer");
            ViewData["Projektnummer"] = new SelectList(_context.Projekt, "Projektnr", "Projektnr");
            return View();
        }

        // POST: ProjektAktivitets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Projektnummer,Aktivitetsnummer,Leverantorsnummer,StartFrom,TillOchMed,Id")] ProjektAktivitet projektAktivitet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projektAktivitet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer", projektAktivitet.Leverantorsnummer);
            ViewData["Projektnummer"] = new SelectList(_context.Projekt, "Projektnr", "Projektnr", projektAktivitet.Projektnummer);
            return View(projektAktivitet);
        }

        // GET: ProjektAktivitets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projektAktivitet = await _context.ProjektAktivitet.FindAsync(id);
            if (projektAktivitet == null)
            {
                return NotFound();
            }
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer", projektAktivitet.Leverantorsnummer);
            ViewData["Projektnummer"] = new SelectList(_context.Projekt, "Projektnr", "Projektnr", projektAktivitet.Projektnummer);
            return View(projektAktivitet);
        }

        // POST: ProjektAktivitets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Projektnummer,Aktivitetsnummer,Leverantorsnummer,StartFrom,TillOchMed,Id")] ProjektAktivitet projektAktivitet)
        {
            if (id != projektAktivitet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projektAktivitet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjektAktivitetExists(projektAktivitet.Id))
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
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer", projektAktivitet.Leverantorsnummer);
            ViewData["Projektnummer"] = new SelectList(_context.Projekt, "Projektnr", "Projektnr", projektAktivitet.Projektnummer);
            return View(projektAktivitet);
        }

        // GET: ProjektAktivitets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projektAktivitet = await _context.ProjektAktivitet
                .Include(p => p.LeverantorsnummerNavigation)
                .Include(p => p.ProjektnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projektAktivitet == null)
            {
                return NotFound();
            }

            return View(projektAktivitet);
        }

        // POST: ProjektAktivitets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projektAktivitet = await _context.ProjektAktivitet.FindAsync(id);
            _context.ProjektAktivitet.Remove(projektAktivitet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjektAktivitetExists(int id)
        {
            return _context.ProjektAktivitet.Any(e => e.Id == id);
        }
    }
}

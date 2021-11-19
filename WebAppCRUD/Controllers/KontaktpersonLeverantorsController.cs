using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class KontaktpersonLeverantorsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public KontaktpersonLeverantorsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: KontaktpersonLeverantors
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.KontaktpersonLeverantor.Include(k => k.LeverantorsnummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: KontaktpersonLeverantors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontaktpersonLeverantor = await _context.KontaktpersonLeverantor
                .Include(k => k.LeverantorsnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontaktpersonLeverantor == null)
            {
                return NotFound();
            }

            return View(kontaktpersonLeverantor);
        }

        // GET: KontaktpersonLeverantors/Create
        public IActionResult Create()
        {
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer");
            return View();
        }

        // POST: KontaktpersonLeverantors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Leverantorsnummer,Radnummer,Fornamn,Efternamn,TelefonDirekt,TelefonHem,TelefonMobil,Id")] KontaktpersonLeverantor kontaktpersonLeverantor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontaktpersonLeverantor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer", kontaktpersonLeverantor.Leverantorsnummer);
            return View(kontaktpersonLeverantor);
        }

        // GET: KontaktpersonLeverantors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontaktpersonLeverantor = await _context.KontaktpersonLeverantor.FindAsync(id);
            if (kontaktpersonLeverantor == null)
            {
                return NotFound();
            }
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer", kontaktpersonLeverantor.Leverantorsnummer);
            return View(kontaktpersonLeverantor);
        }

        // POST: KontaktpersonLeverantors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Leverantorsnummer,Radnummer,Fornamn,Efternamn,TelefonDirekt,TelefonHem,TelefonMobil,Id")] KontaktpersonLeverantor kontaktpersonLeverantor)
        {
            if (id != kontaktpersonLeverantor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontaktpersonLeverantor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontaktpersonLeverantorExists(kontaktpersonLeverantor.Id))
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
            ViewData["Leverantorsnummer"] = new SelectList(_context.Leverantor, "Leverantorsnummer", "Leverantorsnummer", kontaktpersonLeverantor.Leverantorsnummer);
            return View(kontaktpersonLeverantor);
        }

        // GET: KontaktpersonLeverantors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontaktpersonLeverantor = await _context.KontaktpersonLeverantor
                .Include(k => k.LeverantorsnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontaktpersonLeverantor == null)
            {
                return NotFound();
            }

            return View(kontaktpersonLeverantor);
        }

        // POST: KontaktpersonLeverantors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontaktpersonLeverantor = await _context.KontaktpersonLeverantor.FindAsync(id);
            _context.KontaktpersonLeverantor.Remove(kontaktpersonLeverantor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontaktpersonLeverantorExists(int id)
        {
            return _context.KontaktpersonLeverantor.Any(e => e.Id == id);
        }
    }
}

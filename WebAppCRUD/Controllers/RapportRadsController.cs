using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class RapportRadsController(BokforingContext context) : AbstractController(context)
    {
        //private readonly BokforingContext _context;


        // GET: RapportRads
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.RapportRad.Include(r => r.RapportNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: RapportRads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapportRad = await _context.RapportRad
                .Include(r => r.RapportNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapportRad == null)
            {
                return NotFound();
            }

            return View(rapportRad);
        }

        // GET: RapportRads/Create
        public IActionResult Create()
        {
            ViewData["Rapport"] = new SelectList(_context.Rapport, "Rapport1", "Rapport1");
            return View();
        }

        // POST: RapportRads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rapport,Radnr,KontoFrom,KontoTom,RadFromTom,Radbenamning,OmAdderaIb,Id")] RapportRad rapportRad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapportRad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Rapport"] = new SelectList(_context.Rapport, "Rapport1", "Rapport1", rapportRad.Rapport);
            return View(rapportRad);
        }

        // GET: RapportRads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapportRad = await _context.RapportRad.FindAsync(id);
            if (rapportRad == null)
            {
                return NotFound();
            }
            ViewData["Rapport"] = new SelectList(_context.Rapport, "Rapport1", "Rapport1", rapportRad.Rapport);
            return View(rapportRad);
        }

        // POST: RapportRads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rapport,Radnr,KontoFrom,KontoTom,RadFromTom,Radbenamning,OmAdderaIb,Id")] RapportRad rapportRad)
        {
            if (id != rapportRad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapportRad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapportRadExists(rapportRad.Id))
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
            ViewData["Rapport"] = new SelectList(_context.Rapport, "Rapport1", "Rapport1", rapportRad.Rapport);
            return View(rapportRad);
        }

        // GET: RapportRads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapportRad = await _context.RapportRad
                .Include(r => r.RapportNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapportRad == null)
            {
                return NotFound();
            }

            return View(rapportRad);
        }

        // POST: RapportRads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapportRad = await _context.RapportRad.FindAsync(id);
            _context.RapportRad.Remove(rapportRad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapportRadExists(int id)
        {
            return _context.RapportRad.Any(e => e.Id == id);
        }
    }
}

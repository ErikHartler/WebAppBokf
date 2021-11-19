using System.Linq;
using System.Threading.Tasks;
using EFData;
using EfLibrary.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebAppCRUD.Controllers
{
    public class FakturaradsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public FakturaradsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Fakturarads
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.Fakturarad.Include(f => f.EnhetNavigation).Include(f => f.FakturanummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: Fakturarads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakturarad = await _context.Fakturarad
                .Include(f => f.EnhetNavigation)
                .Include(f => f.FakturanummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fakturarad == null)
            {
                return NotFound();
            }

            return View(fakturarad);
        }

        // GET: Fakturarads/Create
        public IActionResult Create()
        {
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1");
            ViewData["Fakturanummer"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer");
            return View();
        }

        // POST: Fakturarads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fakturanummer,Radnummer,ProduktTjanst,Enhetspris,Enhet,SummaKr,Antal,Id")] Fakturarad fakturarad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fakturarad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1", fakturarad.Enhet);
            ViewData["Fakturanummer"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer", fakturarad.Fakturanummer);
            return View(fakturarad);
        }

        // GET: Fakturarads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakturarad = await _context.Fakturarad.FindAsync(id);
            if (fakturarad == null)
            {
                return NotFound();
            }
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1", fakturarad.Enhet);
            ViewData["Fakturanummer"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer", fakturarad.Fakturanummer);
            return View(fakturarad);
        }

        // POST: Fakturarads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fakturanummer,Radnummer,ProduktTjanst,Enhetspris,Enhet,SummaKr,Antal,Id")] Fakturarad fakturarad)
        {
            if (id != fakturarad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fakturarad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakturaradExists(fakturarad.Id))
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
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1", fakturarad.Enhet);
            ViewData["Fakturanummer"] = new SelectList(_context.Faktura, "Fakturanummer", "Fakturanummer", fakturarad.Fakturanummer);
            return View(fakturarad);
        }

        // GET: Fakturarads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakturarad = await _context.Fakturarad
                .Include(f => f.EnhetNavigation)
                .Include(f => f.FakturanummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fakturarad == null)
            {
                return NotFound();
            }

            return View(fakturarad);
        }

        // POST: Fakturarads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fakturarad = await _context.Fakturarad.FindAsync(id);
            _context.Fakturarad.Remove(fakturarad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakturaradExists(int id)
        {
            return _context.Fakturarad.Any(e => e.Id == id);
        }
    }
}

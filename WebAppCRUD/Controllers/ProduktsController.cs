using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class ProduktsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public ProduktsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Produkts
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.Produkt.Include(p => p.EnhetNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: Produkts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .Include(p => p.EnhetNavigation)
                .FirstOrDefaultAsync(m => m.ProduktTjanst == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // GET: Produkts/Create
        public IActionResult Create()
        {
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1");
            return View();
        }

        // POST: Produkts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduktTjanst,Beskrivning,Enhet,Enhetspris")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1", produkt.Enhet);
            return View(produkt);
        }

        // GET: Produkts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1", produkt.Enhet);
            return View(produkt);
        }

        // POST: Produkts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProduktTjanst,Beskrivning,Enhet,Enhetspris")] Produkt produkt)
        {
            if (id != produkt.ProduktTjanst)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.ProduktTjanst))
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
            ViewData["Enhet"] = new SelectList(_context.Enhet, "Enhet1", "Enhet1", produkt.Enhet);
            return View(produkt);
        }

        // GET: Produkts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .Include(p => p.EnhetNavigation)
                .FirstOrDefaultAsync(m => m.ProduktTjanst == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // POST: Produkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var produkt = await _context.Produkt.FindAsync(id);
            _context.Produkt.Remove(produkt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktExists(string id)
        {
            return _context.Produkt.Any(e => e.ProduktTjanst == id);
        }
    }
}

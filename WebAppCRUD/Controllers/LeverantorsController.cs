using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class LeverantorsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public LeverantorsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Leverantors
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.Leverantor.Include(l => l.LandNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: Leverantors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leverantor = await _context.Leverantor
                .Include(l => l.LandNavigation)
                .FirstOrDefaultAsync(m => m.Leverantorsnummer == id);
            if (leverantor == null)
            {
                return NotFound();
            }

            return View(leverantor);
        }

        // GET: Leverantors/Create
        public IActionResult Create()
        {
            ViewData["Land"] = new SelectList(_context.Landskod, "Landskod1", "Landskod1");
            return View();
        }

        // POST: Leverantors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Leverantorsnummer,Namn,Adress,Postnummer,Ort,Land,Telefonnummer,Telefax")] Leverantor leverantor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leverantor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Land"] = new SelectList(_context.Landskod, "Landskod1", "Landskod1", leverantor.Land);
            return View(leverantor);
        }

        // GET: Leverantors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leverantor = await _context.Leverantor.FindAsync(id);
            if (leverantor == null)
            {
                return NotFound();
            }
            ViewData["Land"] = new SelectList(_context.Landskod, "Landskod1", "Landskod1", leverantor.Land);
            return View(leverantor);
        }

        // POST: Leverantors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Leverantorsnummer,Namn,Adress,Postnummer,Ort,Land,Telefonnummer,Telefax")] Leverantor leverantor)
        {
            if (id != leverantor.Leverantorsnummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leverantor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeverantorExists(leverantor.Leverantorsnummer))
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
            ViewData["Land"] = new SelectList(_context.Landskod, "Landskod1", "Landskod1", leverantor.Land);
            return View(leverantor);
        }

        // GET: Leverantors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leverantor = await _context.Leverantor
                .Include(l => l.LandNavigation)
                .FirstOrDefaultAsync(m => m.Leverantorsnummer == id);
            if (leverantor == null)
            {
                return NotFound();
            }

            return View(leverantor);
        }

        // POST: Leverantors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leverantor = await _context.Leverantor.FindAsync(id);
            _context.Leverantor.Remove(leverantor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeverantorExists(int id)
        {
            return _context.Leverantor.Any(e => e.Leverantorsnummer == id);
        }
    }
}

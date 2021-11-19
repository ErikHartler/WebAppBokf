using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class KontoesController : AbstractController
    {
        //private readonly BokforingContext _context;

        public KontoesController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Kontoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Konto.ToListAsync());
        }

        // GET: Kontoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konto = await _context.Konto
                .FirstOrDefaultAsync(m => m.Konto1 == id);
            if (konto == null)
            {
                return NotFound();
            }

            return View(konto);
        }

        // GET: Kontoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kontoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Konto1,Arsredovisningsrad,Benamning,IbDebetKr,IbKreditKr,OmDebet,Skattekonto")] Konto konto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konto);
        }

        // GET: Kontoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konto = await _context.Konto.FindAsync(id);
            if (konto == null)
            {
                return NotFound();
            }
            return View(konto);
        }

        // POST: Kontoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Konto1,Arsredovisningsrad,Benamning,IbDebetKr,IbKreditKr,OmDebet,Skattekonto")] Konto konto)
        {
            if (id != konto.Konto1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontoExists(konto.Konto1))
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
            return View(konto);
        }

        // GET: Kontoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konto = await _context.Konto
                .FirstOrDefaultAsync(m => m.Konto1 == id);
            if (konto == null)
            {
                return NotFound();
            }

            return View(konto);
        }

        // POST: Kontoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var konto = await _context.Konto.FindAsync(id);
            _context.Konto.Remove(konto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontoExists(string id)
        {
            return _context.Konto.Any(e => e.Konto1 == id);
        }
    }
}

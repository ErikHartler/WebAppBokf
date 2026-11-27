using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class PersonalfunktionsController(BokforingContext context) : AbstractController(context)
    {
        //private readonly BokforingContext _context;


        // GET: Personalfunktions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personalfunktion.ToListAsync());
        }

        // GET: Personalfunktions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalfunktion = await _context.Personalfunktion
                .FirstOrDefaultAsync(m => m.Funktion == id);
            if (personalfunktion == null)
            {
                return NotFound();
            }

            return View(personalfunktion);
        }

        // GET: Personalfunktions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personalfunktions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Personalfunktion1,Beskrivning")] Personalfunktion personalfunktion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalfunktion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalfunktion);
        }

        // GET: Personalfunktions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalfunktion = await _context.Personalfunktion.FindAsync(id);
            if (personalfunktion == null)
            {
                return NotFound();
            }
            return View(personalfunktion);
        }

        // POST: Personalfunktions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Personalfunktion1,Beskrivning")] Personalfunktion personalfunktion)
        {
            if (id != personalfunktion.Funktion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalfunktion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalfunktionExists(personalfunktion.Funktion))
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
            return View(personalfunktion);
        }

        // GET: Personalfunktions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalfunktion = await _context.Personalfunktion
                .FirstOrDefaultAsync(m => m.Funktion == id);
            if (personalfunktion == null)
            {
                return NotFound();
            }

            return View(personalfunktion);
        }

        // POST: Personalfunktions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personalfunktion = await _context.Personalfunktion.FindAsync(id);
            _context.Personalfunktion.Remove(personalfunktion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalfunktionExists(string id)
        {
            return _context.Personalfunktion.Any(e => e.Funktion == id);
        }
    }
}

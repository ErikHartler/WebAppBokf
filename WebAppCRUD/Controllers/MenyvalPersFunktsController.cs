using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class MenyvalPersFunktsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public MenyvalPersFunktsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: MenyvalPersFunkts
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.MenyvalPersFunkt.Include(m => m.MenyvalsnummerNavigation).Include(m => m.PersonalfunktionNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: MenyvalPersFunkts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyvalPersFunkt = await _context.MenyvalPersFunkt
                .Include(m => m.MenyvalsnummerNavigation)
                .Include(m => m.PersonalfunktionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menyvalPersFunkt == null)
            {
                return NotFound();
            }

            return View(menyvalPersFunkt);
        }

        // GET: MenyvalPersFunkts/Create
        public IActionResult Create()
        {
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr");
            ViewData["Personalfunktion"] = new SelectList(_context.Personalfunktion, "Personalfunktion1", "Personalfunktion1");
            return View();
        }

        // POST: MenyvalPersFunkts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Personalfunktion,Menyvalsnummer,Id")] MenyvalPersFunkt menyvalPersFunkt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menyvalPersFunkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr", menyvalPersFunkt.Menyvalsnummer);
            ViewData["Personalfunktion"] = new SelectList(_context.Personalfunktion, "Personalfunktion1", "Personalfunktion1", menyvalPersFunkt.Personalfunktion);
            return View(menyvalPersFunkt);
        }

        // GET: MenyvalPersFunkts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyvalPersFunkt = await _context.MenyvalPersFunkt.FindAsync(id);
            if (menyvalPersFunkt == null)
            {
                return NotFound();
            }
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr", menyvalPersFunkt.Menyvalsnummer);
            ViewData["Personalfunktion"] = new SelectList(_context.Personalfunktion, "Personalfunktion1", "Personalfunktion1", menyvalPersFunkt.Personalfunktion);
            return View(menyvalPersFunkt);
        }

        // POST: MenyvalPersFunkts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Personalfunktion,Menyvalsnummer,Id")] MenyvalPersFunkt menyvalPersFunkt)
        {
            if (id != menyvalPersFunkt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menyvalPersFunkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenyvalPersFunktExists(menyvalPersFunkt.Id))
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
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr", menyvalPersFunkt.Menyvalsnummer);
            ViewData["Personalfunktion"] = new SelectList(_context.Personalfunktion, "Personalfunktion1", "Personalfunktion1", menyvalPersFunkt.Personalfunktion);
            return View(menyvalPersFunkt);
        }

        // GET: MenyvalPersFunkts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyvalPersFunkt = await _context.MenyvalPersFunkt
                .Include(m => m.MenyvalsnummerNavigation)
                .Include(m => m.PersonalfunktionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menyvalPersFunkt == null)
            {
                return NotFound();
            }

            return View(menyvalPersFunkt);
        }

        // POST: MenyvalPersFunkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menyvalPersFunkt = await _context.MenyvalPersFunkt.FindAsync(id);
            _context.MenyvalPersFunkt.Remove(menyvalPersFunkt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenyvalPersFunktExists(int id)
        {
            return _context.MenyvalPersFunkt.Any(e => e.Id == id);
        }
    }
}

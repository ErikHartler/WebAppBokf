using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class MeniesController(BokforingContext context) : AbstractController(context)
    {
        //private readonly BokforingContext _context;


        // GET: Menies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meny.ToListAsync());
        }

        // GET: Menies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meny = await _context.Meny
                .FirstOrDefaultAsync(m => m.Kod == id);
            if (meny == null)
            {
                return NotFound();
            }

            return View(meny);
        }

        // GET: Menies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Meny1,Beskrivning,Presentationsordning")] Meny meny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meny);
        }

        // GET: Menies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meny = await _context.Meny.FindAsync(id);
            if (meny == null)
            {
                return NotFound();
            }
            return View(meny);
        }

        // POST: Menies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Meny1,Beskrivning,Presentationsordning")] Meny meny)
        {
            if (id != meny.Kod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenyExists(meny.Kod))
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
            return View(meny);
        }

        // GET: Menies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meny = await _context.Meny
                .FirstOrDefaultAsync(m => m.Kod == id);
            if (meny == null)
            {
                return NotFound();
            }

            return View(meny);
        }

        // POST: Menies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var meny = await _context.Meny.FindAsync(id);
            _context.Meny.Remove(meny);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenyExists(string id)
        {
            return _context.Meny.Any(e => e.Kod == id);
        }
    }
}

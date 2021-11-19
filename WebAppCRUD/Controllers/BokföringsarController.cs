using System.Linq;
using System.Threading.Tasks;
using EFData;
using EfLibrary.EFModels;
using EfLibrary.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppCRUD.Controllers
{
    public class BokföringsarController : AbstractController
    {
        //private readonly BokforingContext _context;

        public BokföringsarController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Bokföringsar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bokföringsar.ToListAsync());
        }

        // GET: Bokföringsar/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokföringsar = await _context.Bokföringsar
                .FirstOrDefaultAsync(m => m.Bokforingsar == id);
            if (bokföringsar == null)
            {
                return NotFound();
            }

            return View(bokföringsar);
        }

        // GET: Bokföringsar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bokföringsar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bokforingsar,Start,Slut,OmStangt")] Bokföringsar bokföringsar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bokföringsar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bokföringsar);
        }

        // GET: Bokföringsar/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokföringsar = await _context.Bokföringsar.FindAsync(id);
            if (bokföringsar == null)
            {
                return NotFound();
            }
            return View(bokföringsar);
        }

        // POST: Bokföringsar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Bokforingsar,Start,Slut,OmStangt")] Bokföringsar bokföringsar)
        {
            if (id != bokföringsar.Bokforingsar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bokföringsar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BokföringsarExists(bokföringsar.Bokforingsar))
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
            return View(bokföringsar);
        }

        // GET: Bokföringsar/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokföringsar = await _context.Bokföringsar
                .FirstOrDefaultAsync(m => m.Bokforingsar == id);
            if (bokföringsar == null)
            {
                return NotFound();
            }

            return View(bokföringsar);
        }

        // POST: Bokföringsar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bokföringsar = await _context.Bokföringsar.FindAsync(id);
            _context.Bokföringsar.Remove(bokföringsar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BokföringsarExists(string id)
        {
            return _context.Bokföringsar.Any(e => e.Bokforingsar == id);
        }
    }
}

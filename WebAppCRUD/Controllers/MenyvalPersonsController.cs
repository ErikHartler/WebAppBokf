using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class MenyvalPersonsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public MenyvalPersonsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: MenyvalPersons
        public async Task<IActionResult> Index()
        {
            var bokforingContext = _context.MenyvalPerson.Include(m => m.MenyvalsnummerNavigation);
            return View(await bokforingContext.ToListAsync());
        }

        // GET: MenyvalPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyvalPerson = await _context.MenyvalPerson
                .Include(m => m.MenyvalsnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menyvalPerson == null)
            {
                return NotFound();
            }

            return View(menyvalPerson);
        }

        // GET: MenyvalPersons/Create
        public IActionResult Create()
        {
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr");
            return View();
        }

        // POST: MenyvalPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Anvandare,Menyvalsnummer,AnvandAntal,AnvandSenast,MakeCmd,Id")] MenyvalPerson menyvalPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menyvalPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr", menyvalPerson.Menyvalsnummer);
            return View(menyvalPerson);
        }

        // GET: MenyvalPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyvalPerson = await _context.MenyvalPerson.FindAsync(id);
            if (menyvalPerson == null)
            {
                return NotFound();
            }
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr", menyvalPerson.Menyvalsnummer);
            return View(menyvalPerson);
        }

        // POST: MenyvalPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Anvandare,Menyvalsnummer,AnvandAntal,AnvandSenast,MakeCmd,Id")] MenyvalPerson menyvalPerson)
        {
            if (id != menyvalPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menyvalPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenyvalPersonExists(menyvalPerson.Id))
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
            ViewData["Menyvalsnummer"] = new SelectList(_context.Menyval, "Menyvalsnr", "Menyvalsnr", menyvalPerson.Menyvalsnummer);
            return View(menyvalPerson);
        }

        // GET: MenyvalPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyvalPerson = await _context.MenyvalPerson
                .Include(m => m.MenyvalsnummerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menyvalPerson == null)
            {
                return NotFound();
            }

            return View(menyvalPerson);
        }

        // POST: MenyvalPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menyvalPerson = await _context.MenyvalPerson.FindAsync(id);
            _context.MenyvalPerson.Remove(menyvalPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenyvalPersonExists(int id)
        {
            return _context.MenyvalPerson.Any(e => e.Id == id);
        }
    }
}

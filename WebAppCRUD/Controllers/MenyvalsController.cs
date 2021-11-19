using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class MenyvalsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public MenyvalsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Menyvals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menyval.ToListAsync());
        }

        // GET: Menyvals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyval = await _context.Menyval
                .FirstOrDefaultAsync(m => m.Menyvalsnr == id);
            if (menyval == null)
            {
                return NotFound();
            }

            return View(menyval);
        }

        // GET: Menyvals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menyvals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Menyvalsnr,Menyval1,Meny,Beskrivning,Form,Report,Query,ShellFunction")] Menyval menyval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menyval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menyval);
        }

        // GET: Menyvals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyval = await _context.Menyval.FindAsync(id);
            if (menyval == null)
            {
                return NotFound();
            }
            return View(menyval);
        }

        // POST: Menyvals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Menyvalsnr,Menyval1,Meny,Beskrivning,Form,Report,Query,ShellFunction")] Menyval menyval)
        {
            if (id != menyval.Menyvalsnr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menyval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenyvalExists(menyval.Menyvalsnr))
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
            return View(menyval);
        }

        // GET: Menyvals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menyval = await _context.Menyval
                .FirstOrDefaultAsync(m => m.Menyvalsnr == id);
            if (menyval == null)
            {
                return NotFound();
            }

            return View(menyval);
        }

        // POST: Menyvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menyval = await _context.Menyval.FindAsync(id);
            _context.Menyval.Remove(menyval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenyvalExists(int id)
        {
            return _context.Menyval.Any(e => e.Menyvalsnr == id);
        }
    }
}

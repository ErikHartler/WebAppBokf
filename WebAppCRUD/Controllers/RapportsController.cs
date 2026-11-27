using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFData;
using EfLibrary.EFModels;
namespace WebAppCRUD.Controllers
{
    public class RapportsController(BokforingContext context) : AbstractController(context)
    {
        //private readonly BokforingContext _context;


        // GET: Rapports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rapport.ToListAsync());
        }

        // GET: Rapports/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapport
                .FirstOrDefaultAsync(m => m.Rapport1 == id);
            if (rapport == null)
            {
                return NotFound();
            }

            return View(rapport);
        }

        // GET: Rapports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rapports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rapport1,Benamning,OmTeckenvandning,OmKol2Ib,Kommentar")] Rapport rapport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rapport);
        }

        // GET: Rapports/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapport.FindAsync(id);
            if (rapport == null)
            {
                return NotFound();
            }
            return View(rapport);
        }

        // POST: Rapports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Rapport1,Benamning,OmTeckenvandning,OmKol2Ib,Kommentar")] Rapport rapport)
        {
            if (id != rapport.Rapport1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapportExists(rapport.Rapport1))
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
            return View(rapport);
        }

        // GET: Rapports/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapport = await _context.Rapport
                .FirstOrDefaultAsync(m => m.Rapport1 == id);
            if (rapport == null)
            {
                return NotFound();
            }

            return View(rapport);
        }

        // POST: Rapports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rapport = await _context.Rapport.FindAsync(id);
            _context.Rapport.Remove(rapport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapportExists(string id)
        {
            return _context.Rapport.Any(e => e.Rapport1 == id);
        }
    }
}

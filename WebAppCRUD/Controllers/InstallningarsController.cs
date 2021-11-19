using System.Linq;
using System.Threading.Tasks;
using EFData;
using EfLibrary.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppCRUD.Controllers
{
    public class InstallningarsController : AbstractController
    {
        //private readonly BokforingContext _context;

        public InstallningarsController(BokforingContext context) :base(context)
        {
            //_context = context;
        }

        // GET: Installningars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Installningar.ToListAsync());
        }

        // GET: Installningars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installningar = await _context.Installningar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installningar == null)
            {
                return NotFound();
            }

            return View(installningar);
        }

        // GET: Installningars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Installningars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BokforingsarFrom,BokforingsarTom,Bolagsnamn,Organisationsnr,KontoIngMoms,KontoUtgMoms,KontoMomsAvstamning,KontoIntakterFrom,KontoIntakterTom,KontoIntakterKund,KontoFordranFrom,KontoFordranTom,KontoFordranKund,Id")] Installningar installningar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(installningar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(installningar);
        }

        // GET: Installningars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installningar = await _context.Installningar.FindAsync(id);
            if (installningar == null)
            {
                return NotFound();
            }
            return View(installningar);
        }

        // POST: Installningars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BokforingsarFrom,BokforingsarTom,Bolagsnamn,Organisationsnr,KontoIngMoms,KontoUtgMoms,KontoMomsAvstamning,KontoIntakterFrom,KontoIntakterTom,KontoIntakterKund,KontoFordranFrom,KontoFordranTom,KontoFordranKund,Id")] Installningar installningar)
        {
            if (id != installningar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(installningar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstallningarExists(installningar.Id))
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
            return View(installningar);
        }

        // GET: Installningars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installningar = await _context.Installningar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installningar == null)
            {
                return NotFound();
            }

            return View(installningar);
        }

        // POST: Installningars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var installningar = await _context.Installningar.FindAsync(id);
            _context.Installningar.Remove(installningar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstallningarExists(int id)
        {
            return _context.Installningar.Any(e => e.Id == id);
        }
    }
}

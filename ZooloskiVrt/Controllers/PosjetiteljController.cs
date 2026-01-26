using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Data;
using ZooloskiVrt.Models;

namespace ZooloskiVrt.Controllers
{
    public class PosjetiteljController : Controller
    {
        private readonly ZooloskiVrtContext _context;

        public PosjetiteljController(ZooloskiVrtContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var posjetitelji = await _context.Posjetitelji
                .Include(p => p.Vodic)
                .ToListAsync();
            return View(posjetitelji);
        }

        
        public IActionResult Create()
        {
            ViewData["VodicID"] = new SelectList(
                _context.Radnici.Select(r => new { r.ID, ImePrezime = r.Ime + " " + r.Prezime }),
                "ID", "ImePrezime"
            );
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Posjetitelj posjetitelj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posjetitelj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["VodicID"] = new SelectList(
                _context.Radnici.Select(r => new { r.ID, ImePrezime = r.Ime + " " + r.Prezime }),
                "ID", "ImePrezime", posjetitelj.VodicID
            );

            return View(posjetitelj);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var posjetitelj = await _context.Posjetitelji.FindAsync(id);
            if (posjetitelj == null) return NotFound();

            ViewData["VodicID"] = new SelectList(
                _context.Radnici.Select(r => new { r.ID, ImePrezime = r.Ime + " " + r.Prezime }),
                "ID", "ImePrezime", posjetitelj.VodicID
            );

            return View(posjetitelj);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Posjetitelj posjetitelj)
        {
            if (id != posjetitelj.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posjetitelj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Posjetitelji.Any(e => e.ID == posjetitelj.ID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["VodicID"] = new SelectList(
                _context.Radnici.Select(r => new { r.ID, ImePrezime = r.Ime + " " + r.Prezime }),
                "ID", "ImePrezime", posjetitelj.VodicID
            );

            return View(posjetitelj);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var posjetitelj = await _context.Posjetitelji
                .Include(p => p.Vodic)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (posjetitelj == null) return NotFound();

            return View(posjetitelj);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posjetitelj = await _context.Posjetitelji.FindAsync(id);
            if (posjetitelj != null)
            {
                _context.Posjetitelji.Remove(posjetitelj);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

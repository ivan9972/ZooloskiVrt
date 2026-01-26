using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Data;
using ZooloskiVrt.Models;

namespace ZooloskiVrt.Controllers
{
    public class NastambaController : Controller
    {
        private readonly ZooloskiVrtContext _context;

        public NastambaController(ZooloskiVrtContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Nastambe";

            var nastambe = await _context.Nastambe
                .OrderBy(n => n.Naziv)
                .ToListAsync();

            return View(nastambe);
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var nastamba = await _context.Nastambe
                .Include(n => n.Zivotinje)
                .FirstOrDefaultAsync(n => n.ID == id);

            if (nastamba == null) return NotFound();

            ViewData["Title"] = $"Nastamba: {nastamba.Naziv}";
            return View(nastamba);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Dodaj nastambu";
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nastamba nastamba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nastamba);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Nastamba je uspješno dodana.";
                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "Dodaj nastambu";
            return View(nastamba);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var nastamba = await _context.Nastambe.FindAsync(id);
            if (nastamba == null) return NotFound();

            ViewData["Title"] = "Uredi nastambu";
            return View(nastamba);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Nastamba nastamba)
        {
            if (id != nastamba.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nastamba);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Promjene su spremljene.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Nastambe.Any(e => e.ID == id)) return NotFound();
                    throw;
                }
            }

            ViewData["Title"] = "Uredi nastambu";
            return View(nastamba);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var nastamba = await _context.Nastambe
                .FirstOrDefaultAsync(m => m.ID == id);

            if (nastamba == null) return NotFound();

            ViewData["Title"] = "Obriši nastambu";
            return View(nastamba);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nastamba = await _context.Nastambe.FindAsync(id);

            if (nastamba != null)
            {
                _context.Nastambe.Remove(nastamba);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Nastamba je obrisana.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

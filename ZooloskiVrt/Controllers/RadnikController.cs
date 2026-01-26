using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Data;
using ZooloskiVrt.Models;

namespace ZooloskiVrt.Controllers
{
    public class RadnikController : Controller
    {
        private readonly ZooloskiVrtContext _context;
        public RadnikController(ZooloskiVrtContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var radnici = await _context.Radnici.ToListAsync();
            ViewData["Title"] = "Radnici";
            return View(radnici);
        }

        
        public IActionResult Create()
        {
            ViewData["Title"] = "Dodaj radnika";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Radnik radnik)
        {
            if (ModelState.IsValid)
            {
                _context.Radnici.Add(radnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(radnik);
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var radnik = await _context.Radnici.FindAsync(id);
            if (radnik == null) return NotFound();
            ViewData["Title"] = "Uredi radnika";
            return View(radnik);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Radnik radnik)
        {
            if (id != radnik.ID) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(radnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(radnik);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var radnik = await _context.Radnici.FindAsync(id);
            if (radnik == null) return NotFound();
            ViewData["Title"] = "Obriši radnika";
            return View(radnik);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var radnik = await _context.Radnici.FindAsync(id);
            if (radnik != null)
            {
                _context.Radnici.Remove(radnik);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

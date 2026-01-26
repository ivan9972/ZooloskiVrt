using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Data;
using ZooloskiVrt.Models;

namespace ZooloskiVrt.Controllers
{
    public class ObavezaController : Controller
    {
        private readonly ZooloskiVrtContext _context;
        public ObavezaController(ZooloskiVrtContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Obaveze";

            var obaveze = await _context.Obaveze
                .Include(o => o.Radnik)
                .Include(o => o.Nastamba)
                    .ThenInclude(n => n.Zivotinje) 
                .OrderByDescending(o => o.Datum)
                .ToListAsync();

            return View(obaveze);
        }

        
        public IActionResult Create()
        {
            ViewData["RadnikID"] = new SelectList(_context.Radnici.OrderBy(r => r.Prezime).ThenBy(r => r.Ime), "ID", "Ime");
            ViewData["NastambaID"] = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv");
            ViewData["Title"] = "Dodaj obavezu";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Obaveza obaveza)
        {
            if (ModelState.IsValid)
            {
                _context.Obaveze.Add(obaveza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RadnikID"] = new SelectList(_context.Radnici.OrderBy(r => r.Prezime).ThenBy(r => r.Ime), "ID", "Ime", obaveza.RadnikID);
            ViewData["NastambaID"] = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv", obaveza.NastambaID);
            return View(obaveza);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var obaveza = await _context.Obaveze.FindAsync(id);
            if (obaveza == null) return NotFound();

            ViewData["RadnikID"] = new SelectList(_context.Radnici.OrderBy(r => r.Prezime).ThenBy(r => r.Ime), "ID", "Ime", obaveza.RadnikID);
            ViewData["NastambaID"] = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv", obaveza.NastambaID);
            ViewData["Title"] = "Uredi obavezu";
            return View(obaveza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Obaveza obaveza)
        {
            if (id != obaveza.ID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(obaveza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["RadnikID"] = new SelectList(_context.Radnici.OrderBy(r => r.Prezime).ThenBy(r => r.Ime), "ID", "Ime", obaveza.RadnikID);
            ViewData["NastambaID"] = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv", obaveza.NastambaID);
            return View(obaveza);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var obaveza = await _context.Obaveze
                .Include(o => o.Radnik)
                .Include(o => o.Nastamba)
                .FirstOrDefaultAsync(o => o.ID == id);

            if (obaveza == null) return NotFound();

            ViewData["Title"] = "Obriši obavezu";
            return View(obaveza);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obaveza = await _context.Obaveze.FindAsync(id);
            if (obaveza != null)
            {
                _context.Obaveze.Remove(obaveza);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

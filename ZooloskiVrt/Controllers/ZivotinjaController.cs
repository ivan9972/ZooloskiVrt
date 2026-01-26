using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Data;
using ZooloskiVrt.Models;

namespace ZooloskiVrt.Controllers
{
    public class ZivotinjaController : Controller
    {
        private readonly ZooloskiVrtContext _context;

        public ZivotinjaController(ZooloskiVrtContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var zivotinje = await _context.Zivotinje
                .Include(z => z.Nastamba)
                .OrderBy(z => z.Ime)
                .ToListAsync();

            ViewData["Title"] = "Životinje";
            return View(zivotinje);
        }

        
        public IActionResult Create()
        {
            ViewData["Title"] = "Dodaj životinju";
            ViewBag.Nastambe = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv");

            return View(new Zivotinja
            {
                DatumNabave = DateTime.Today,
                Aktivna = true
            });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Zivotinja zivotinja)
        {
            
            zivotinja.DatumNabave = (zivotinja.DatumNabave == default ? DateTime.Today : zivotinja.DatumNabave.Date);

            if (!ModelState.IsValid)
            {
                ViewBag.Nastambe = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv", zivotinja.NastambaID);
                return View(zivotinja);
            }

            _context.Zivotinje.Add(zivotinja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var zivotinja = await _context.Zivotinje.FindAsync(id);
            if (zivotinja == null) return NotFound();

            ViewData["Title"] = "Uredi životinju";
            ViewBag.Nastambe = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv", zivotinja.NastambaID);

            return View(zivotinja);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Zivotinja zivotinja)
        {
            if (id != zivotinja.ID) return NotFound();

            zivotinja.DatumNabave = (zivotinja.DatumNabave == default ? DateTime.Today : zivotinja.DatumNabave.Date);

            if (!ModelState.IsValid)
            {
                ViewBag.Nastambe = new SelectList(_context.Nastambe.OrderBy(n => n.Naziv), "ID", "Naziv", zivotinja.NastambaID);
                return View(zivotinja);
            }

            var dbZivotinja = await _context.Zivotinje.FirstOrDefaultAsync(z => z.ID == id);
            if (dbZivotinja == null) return NotFound();

            dbZivotinja.Ime = zivotinja.Ime;
            dbZivotinja.LatinskiNaziv = zivotinja.LatinskiNaziv;
            dbZivotinja.HrvatskiNaziv = zivotinja.HrvatskiNaziv;
            dbZivotinja.NacinNabave = zivotinja.NacinNabave;
            dbZivotinja.DatumNabave = zivotinja.DatumNabave;
            dbZivotinja.Aktivna = zivotinja.Aktivna;
            dbZivotinja.NastambaID = zivotinja.NastambaID;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var zivotinja = await _context.Zivotinje
                .Include(z => z.Nastamba)
                .FirstOrDefaultAsync(z => z.ID == id);

            if (zivotinja == null) return NotFound();

            ViewData["Title"] = "Obriši životinju";
            return View(zivotinja);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zivotinja = await _context.Zivotinje.FindAsync(id);
            if (zivotinja != null)
            {
                _context.Zivotinje.Remove(zivotinja);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

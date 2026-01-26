using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Data;
using ZooloskiVrt.Models;

namespace ZooloskiVrt.Controllers
{
    public class IncidentController : Controller
    {
        private readonly ZooloskiVrtContext _context;
        public IncidentController(ZooloskiVrtContext context)
        {
            _context = context;
        }

   
        public async Task<IActionResult> Index()
        {
            var incidenti = await _context.Incidenti
                .Include(i => i.IncidentiNastambe)
                    .ThenInclude(n => n.Nastamba)
                .Include(i => i.IncidentiZivotinje)
                    .ThenInclude(z => z.Zivotinja)
                .ToListAsync();

            ViewData["Title"] = "Incidenti";
            return View(incidenti);
        }

       
        public IActionResult Create()
        {
            ViewData["Nastambe"] = new MultiSelectList(_context.Nastambe, "ID", "Naziv");
            ViewData["Zivotinje"] = new MultiSelectList(_context.Zivotinje, "ID", "Ime");
            ViewData["Title"] = "Dodaj incident";
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(Incident incident, int[] Nastambe, int[] Zivotinje)
        {
            if (ModelState.IsValid)
            {
                _context.Incidenti.Add(incident);
                await _context.SaveChangesAsync();

               
                foreach (var nId in Nastambe)
                {
                    _context.IncidentNastambe.Add(new IncidentNastamba
                    {
                        IncidentID = incident.ID,
                        NastambaID = nId
                    });
                }

                foreach (var zId in Zivotinje)
                {
                    _context.IncidentZivotinje.Add(new IncidentZivotinja
                    {
                        IncidentID = incident.ID,
                        ZivotinjaID = zId
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Nastambe"] = new MultiSelectList(_context.Nastambe, "ID", "Naziv", Nastambe);
            ViewData["Zivotinje"] = new MultiSelectList(_context.Zivotinje, "ID", "Ime", Zivotinje);
            return View(incident);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var incident = await _context.Incidenti
                .Include(i => i.IncidentiNastambe)
                .Include(i => i.IncidentiZivotinje)
                .FirstOrDefaultAsync(i => i.ID == id);

            if (incident == null) return NotFound();

            ViewData["Nastambe"] = new MultiSelectList(_context.Nastambe, "ID", "Naziv", incident.IncidentiNastambe?.Select(n => n.NastambaID));
            ViewData["Zivotinje"] = new MultiSelectList(_context.Zivotinje, "ID", "Ime", incident.IncidentiZivotinje?.Select(z => z.ZivotinjaID));
            ViewData["Title"] = "Uredi incident";
            return View(incident);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Incident incident, int[] Nastambe, int[] Zivotinje)
        {
            if (id != incident.ID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(incident);
                await _context.SaveChangesAsync();

                
                var postojeceN = _context.IncidentNastambe
                    .Where(n => n.IncidentID == id)
                    .ToList();
                _context.IncidentNastambe.RemoveRange(postojeceN);
                foreach (var nId in Nastambe)
                {
                    _context.IncidentNastambe.Add(new IncidentNastamba
                    {
                        IncidentID = id,
                        NastambaID = nId
                    });
                }

                
                var postojeceZ = _context.IncidentZivotinje
                    .Where(z => z.IncidentID == id)
                    .ToList();
                _context.IncidentZivotinje.RemoveRange(postojeceZ);
                foreach (var zId in Zivotinje)
                {
                    _context.IncidentZivotinje.Add(new IncidentZivotinja
                    {
                        IncidentID = id,
                        ZivotinjaID = zId
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Nastambe"] = new MultiSelectList(_context.Nastambe, "ID", "Naziv", Nastambe);
            ViewData["Zivotinje"] = new MultiSelectList(_context.Zivotinje, "ID", "Ime", Zivotinje);
            return View(incident);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var incident = await _context.Incidenti
                .Include(i => i.IncidentiNastambe)
                    .ThenInclude(n => n.Nastamba)
                .Include(i => i.IncidentiZivotinje)
                    .ThenInclude(z => z.Zivotinja)
                .FirstOrDefaultAsync(i => i.ID == id);

            if (incident == null) return NotFound();
            ViewData["Title"] = "Obriši incident";
            return View(incident);
        }

       
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incidenti
                .Include(i => i.IncidentiNastambe)
                .Include(i => i.IncidentiZivotinje)
                .FirstOrDefaultAsync(i => i.ID == id);

            if (incident != null)
            {
                _context.IncidentNastambe.RemoveRange(incident.IncidentiNastambe.ToList());
                _context.IncidentZivotinje.RemoveRange(incident.IncidentiZivotinje.ToList());
                _context.Incidenti.Remove(incident);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

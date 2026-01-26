using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooloskiVrt.Models
{
    public class Nastamba
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Naziv nastambe je obavezan.")]
        [Display(Name = "Naziv")]
        public string Naziv { get; set; }

        [Display(Name = "Tip")]
        public string? Tip { get; set; }

        [Display(Name = "Razina osunèanosti")]
        public string? RazinaOsuncanosti { get; set; }

        // Navigacijska svojstva
        public ICollection<Zivotinja>? Zivotinje { get; set; }
        public ICollection<Obaveza>? Obaveze { get; set; }
        public ICollection<IncidentNastamba>? IncidentiNastambe { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooloskiVrt.Models
{
    public class Nastamba
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Naziv { get; set; }
        public string? Tip { get; set; }
        public string? RazinaOsuncanosti { get; set; }

        public ICollection<Zivotinja>? Zivotinje { get; set; }
        public ICollection<Obaveza>? Obaveze { get; set; }
        public ICollection<IncidentNastamba>? IncidentiNastambe { get; set; }
    }
}
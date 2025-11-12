using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooloskiVrt.Models
{
    public class Incident
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public string? Ozbiljnost { get; set; }

        public ICollection<IncidentNastamba>? IncidentiNastambe { get; set; }
        public ICollection<IncidentZivotinja>? IncidentiZivotinje { get; set; }
        public ICollection<Sanacija>? Sanacije { get; set; }
    }
}
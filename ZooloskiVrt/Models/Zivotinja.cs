using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class Zivotinja
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Ime { get; set; }
        public string? LatinskiNaziv { get; set; }
        public string? HrvatskiNaziv { get; set; }
        public string? NacinNabave { get; set; }
        public DateTime DatumNabave { get; set; }
        public bool Aktivna { get; set; }

        [ForeignKey(nameof(Nastamba))]
        public int NastambaID { get; set; }
        public Nastamba Nastamba { get; set; }

        public ICollection<IncidentZivotinja>? IncidentiZivotinje { get; set; }
        public ICollection<Trosak>? Troskovi { get; set; }
    }
}
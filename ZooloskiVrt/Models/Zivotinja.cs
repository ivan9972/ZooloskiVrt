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

        [Required(ErrorMessage = "Ime je obavezno.")]
        public string Ime { get; set; } = string.Empty;

        public string? LatinskiNaziv { get; set; }
        public string? HrvatskiNaziv { get; set; }
        public string? NacinNabave { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumNabave { get; set; }

        public bool Aktivna { get; set; }

        [ForeignKey(nameof(Nastamba))]
        [Range(1, int.MaxValue, ErrorMessage = "Odaberi nastambu.")]
        public int NastambaID { get; set; }

        public Nastamba? Nastamba { get; set; }

        public ICollection<IncidentZivotinja>? IncidentiZivotinje { get; set; }
        public ICollection<Trosak>? Troskovi { get; set; }
    }
}

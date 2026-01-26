using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class Obaveza
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Opis je obavezan.")]
        public string Opis { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public string? Status { get; set; }

        [ForeignKey(nameof(Radnik))]
        [Range(1, int.MaxValue, ErrorMessage = "Odaberi radnika.")]
        public int RadnikID { get; set; }

        public Radnik? Radnik { get; set; }

        [ForeignKey(nameof(Nastamba))]
        [Range(1, int.MaxValue, ErrorMessage = "Odaberi nastambu.")]
        public int NastambaID { get; set; }

        public Nastamba? Nastamba { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class Obaveza
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public string? Status { get; set; }

        [ForeignKey(nameof(Radnik))]
        public int RadnikID { get; set; }
        public Radnik Radnik { get; set; }

        [ForeignKey(nameof(Nastamba))]
        public int NastambaID { get; set; }
        public Nastamba Nastamba { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class Sanacija
    {
        [Key]
        public int ID { get; set; }
        public string Opis { get; set; }
        public decimal Trosak { get; set; }

        [ForeignKey(nameof(Incident))]
        public int IncidentID { get; set; }
        public Incident Incident { get; set; }

        [ForeignKey(nameof(Radnik))]
        public int RadnikID { get; set; }
        public Radnik Radnik { get; set; }
    }
}
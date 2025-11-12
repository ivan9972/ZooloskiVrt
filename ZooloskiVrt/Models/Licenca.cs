using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class Licenca
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public bool Trajna { get; set; }
        public DateTime? DatumIsteka { get; set; }

        [ForeignKey(nameof(Radnik))]
        public int RadnikID { get; set; }
        public Radnik Radnik { get; set; }
    }
}
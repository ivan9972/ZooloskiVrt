using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class GodisnjiOdmor
    {
        [Key]
        public int ID { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        [ForeignKey(nameof(Radnik))]
        public int RadnikID { get; set; }
        public Radnik Radnik { get; set; }
    }
}
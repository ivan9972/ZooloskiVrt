using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class Posjetitelj
    {
        [Key]
        public int ID { get; set; }
        public string ImeGrupe { get; set; }
        public DateTime TerminPosjete { get; set; }

        [ForeignKey(nameof(Vodic))]
        public int? VodicID { get; set; }
        public Radnik Vodic { get; set; }
    }
}
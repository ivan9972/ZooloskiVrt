using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooloskiVrt.Models
{
    public class Radnik
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public string? Kontakt { get; set; }
        public string? Email { get; set; }
        public string? Obrazovanje { get; set; }

        public ICollection<Obaveza>? Obaveze { get; set; }
        public ICollection<Licenca>? Licence { get; set; }
        public ICollection<Obuka>? Obuke { get; set; }
        public ICollection<Smjena>? Smjene { get; set; }
        public ICollection<GodisnjiOdmor>? GodisnjiOdmori { get; set; }
        public ICollection<Bolovanje>? Bolovanja { get; set; }
        public ICollection<Sanacija>? Sanacije { get; set; }
    }
}
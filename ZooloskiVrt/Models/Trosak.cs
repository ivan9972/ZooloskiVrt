using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class Trosak
    {
        [Key]
        public int ID { get; set; }
        public string Vrsta { get; set; }
        public decimal Iznos { get; set; }

        [ForeignKey(nameof(Zivotinja))]
        public int ZivotinjaID { get; set; }
        public Zivotinja Zivotinja { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class IncidentZivotinja
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Incident))]
        public int IncidentID { get; set; }
        public Incident Incident { get; set; }

        [ForeignKey(nameof(Zivotinja))]
        public int ZivotinjaID { get; set; }
        public Zivotinja Zivotinja { get; set; }
    }
}
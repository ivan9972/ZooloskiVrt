using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooloskiVrt.Models
{
    public class IncidentNastamba
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Incident))]
        public int IncidentID { get; set; }
        public Incident Incident { get; set; }

        [ForeignKey(nameof(Nastamba))]
        public int NastambaID { get; set; }
        public Nastamba Nastamba { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuurcontractEntity
    {
        [Key]
        [MaxLength(25)]
        public string Id { get; set; }
                
        public int HuurperiodeId { get; set; }
        public virtual HuurperiodeEntity Huurperiode { get; set; }
        [ForeignKey("Huurder")]
        public int HuurderId { get; set; }
        public virtual HuurderEntity Huurder { get; set; }
        [ForeignKey("Huis")]
        public int HuisId { get; set; }
        public virtual HuisEntity Huis { get; set; }
    }
}

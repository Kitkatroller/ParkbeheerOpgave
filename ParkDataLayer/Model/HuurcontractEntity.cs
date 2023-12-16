using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuurcontractEntity
    {
        [Key]
        public string Id { get; set; }
                
        public int HuurperiodeId { get; set; }
        public virtual HuurperiodeEntity Huurperiode { get; set; }

        public int HuurderId { get; set; }
        public virtual HuurderEntity Huurder { get; set; }

        public int HuisId { get; set; }
        public virtual HuisEntity Huis { get; set; }
    }
}

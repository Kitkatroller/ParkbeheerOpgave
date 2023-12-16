using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class HuurderEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }
                
        public virtual ContactgegevensEntity Contactgegevens { get; set; }
    }
}

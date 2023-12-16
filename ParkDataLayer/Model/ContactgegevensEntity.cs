using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class ContactgegevensEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Tel { get; set; }
        [Required]
        [MaxLength(100)]
        public string Adres { get; set; }
    }
}

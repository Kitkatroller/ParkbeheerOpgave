using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class ContactgegevensEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Adres { get; set; }
    }
}

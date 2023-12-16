using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class ParkEntity
    {
        [Key]
        [MaxLength(20)]
        public string Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Naam { get; set; }
        [MaxLength(500)]
        public string Locatie { get; set; }

        public virtual ICollection<HuisEntity> Huizen { get; set; }

        //Constructors
        public ParkEntity() { }

        public ParkEntity(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class ParkEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Naam { get; set; }
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

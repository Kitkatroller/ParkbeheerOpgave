using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuisEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Straat { get; set; }
        public int Nr { get; set; }
        public bool Actief { get; set; }
                
        public string ParkId { get; set; }
        public virtual ParkEntity Park { get; set; }
                
        public virtual ICollection<HuurcontractEntity> Huurcontracten { get; set; }

        //Constuctors
        public HuisEntity() { }
        public HuisEntity( string straat, int nr, bool actief)
        {
            Straat = straat;
            Nr = nr;
            Actief = actief;
        }
    }
}

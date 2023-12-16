using System;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class HuurperiodeEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartDatum { get; set; }
        [Required]
        public DateTime EindDatum { get; set; }
        [Required]
        public int Aantaldagen { get; set; }
    }
}

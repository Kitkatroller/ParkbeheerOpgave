using System;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class HuurperiodeEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int Aantaldagen { get; set; }
    }
}

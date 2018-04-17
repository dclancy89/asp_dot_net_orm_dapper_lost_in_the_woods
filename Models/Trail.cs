using System;
using System.ComponentModel.DataAnnotations;
namespace LostInTheWoods.Models
{
    public class Trail : BaseEntity {
        
        [Key]
        public int Id { get; set; }
        public string TrailName { get; set; }

        public string Description { get; set; }

        public float TrailLength { get; set; }

        public int ElevationGain { get; set; }

        public string Longitude { get; set; }

        public string Lattitude { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
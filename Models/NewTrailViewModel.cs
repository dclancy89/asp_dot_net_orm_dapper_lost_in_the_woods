using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class NewTrailViewModel : BaseEntity
    {
        [Required]
        [Display(Name="Trail Name")]
        public string TrailName { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name="Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name="Trail Length")]
        public float TrailLength { get; set; }

        [Required]
        [Display(Name="Elevation Change")]
        public int ElevationGain { get; set; }

        [Required]
        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage="Enter using proper format.")]
        [Display(Name="Longitude")]
        public string Longitude { get; set; }

        [Required]
        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage="Enter using proper format.")]
        [Display(Name="Lattitude")]
        public string Lattitude { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace TravelRatings.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }
    [Required]
    [StringLength(56)]
    [Display(Name = "Country")]
    public string Country { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    [Range(0, 10, ErrorMessage = "Age must be between 0 and 10.")]
    public decimal AverageRating { get; set; }
  }
}
using System.ComponentModel.DataAnnotations;

namespace TravelRatings.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    [Required]
    public string ReviewerName { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    [Required]
    public int Rating { get; set; }
  }
}
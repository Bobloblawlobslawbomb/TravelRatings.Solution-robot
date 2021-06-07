namespace TravelRatings.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public decimal AverageRating { get; set; }
  }
}
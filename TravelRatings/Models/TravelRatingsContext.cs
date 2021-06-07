using Microsoft.EntityFrameworkCore;

namespace TravelRatings.Models
{
  public class TravelRatingsContext : DbContext
  {
    public TravelRatingsContext(DbContextOptions<TravelRatingsContext> options)
      : base(options)
    {
    }

    public DbSet<Destination> Destinations { get; set; }
  }
}
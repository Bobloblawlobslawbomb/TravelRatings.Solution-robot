using Microsoft.EntityFrameworkCore;

namespace TravelRatings.Models
{
  public class TravelRatingsContext : DbContext
  {
    public TravelRatingsContext(DbContextOptions<TravelRatingsContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Destination>()
      .HasData(
        new Destination { DestinationId = 1, Country = "United States", City = "Portland", AverageRating = 3.14M }
      );
    }
    public DbSet<Destination> Destinations { get; set; }
  }
}
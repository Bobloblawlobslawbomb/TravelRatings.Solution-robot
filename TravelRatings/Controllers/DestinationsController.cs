using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelRatings.Models;

namespace TravelRatings.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelRatingsContext _db;
    public DestinationsController(TravelRatingsContext db)
    {
      _db = db;
    }

    //Get api/destinations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get()
    {
      return await _db.Destinations.ToListAsync();
    }

    //Post api/destinations
    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destinations.Add(destination);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { IDbContextFactory = destination.DestinationId }, destination);
    }

    //GET: api/Destinations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);

      if (destination == null)
      {
        return NotFound();
      }

      //return destination;
      return CreatedAtAction(nameof(GetDestination), new { id = destination.DestinationId }, destination);
    }
  }
}
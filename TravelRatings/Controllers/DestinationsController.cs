using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelRatings.Models;
using System.Linq;
using System;

namespace TravelRatings.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelRatingsContext _db;
    public DestinationsController(TravelRatingsContext db)
    {
      _db = db;
    }

    //GET api/destinations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string country, string city)
    {
      var query = _db.Destinations.AsQueryable();
      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      return await query.ToListAsync();
    }

    // [HttpGet]
    // public async Task<IEnumerable<Destination>> Get()//made async
    // {
    //   var rng = new Random();
    //   //int Dcount = new { id = destination.DestinationId }
    //   int Dcount = await DestinationId;//new line
    //   return Enumerable.Range(1, 5).Select(index => new Destination
    //   {
    //     RandomDestination = rng.Next(1, 55)
    //   })
    //   .ToArray();
    // }

    //POST api/destinations
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

    //PUT: api/Destinations/[Id]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Entry(destination).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(e => e.DestinationId == id);
    }

    //DELETE: api/Destinations/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelRatings.Models;
using System.Linq;

namespace TravelRatings.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  [ApiVersion("1.1")]
  [ApiVersion("2.0")]
  public class DefaultController : ControllerBase
  {
    string[] authors = new string[]
    { "Joydip Kanjilal", "Steve Smith", "Stephen Jones" };
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return authors;
    }
  }
}
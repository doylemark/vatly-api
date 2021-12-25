using Microsoft.AspNetCore.Mvc;
using Vatly.Api.Data;
using Vatly.Api.Models;

namespace Vatly.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SampleController : ControllerBase
{
  private readonly ApplicationDbContext _dbContext;

  public SampleController(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  [HttpGet]
  [Route("")]
  public ActionResult<Flight> GetSample()
  {
    var sampleFlight = _dbContext.Flights
        .FirstOrDefault(f => f.Callsign == "EIN124");

    if (sampleFlight == null)
      return NotFound();

    return sampleFlight;
  }
}
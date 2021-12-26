using Microsoft.AspNetCore.Mvc;
using Vatly.Api.Data;
using Vatly.Api.Models;
using Vatly.Api.Services;

namespace Vatly.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SampleController : ControllerBase
{
  private readonly ApplicationDbContext dbContext;
  private readonly MetarService metarService;

  public SampleController(ApplicationDbContext dbContext, MetarService metarService)
  {
    this.dbContext = dbContext;
    this.metarService = metarService;
  }

  [HttpGet]
  [Route("")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IEnumerable<Metar>> GetSample()
  {
    var metars = await metarService.FetchMetars();

    return metars.Take(5);
  }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vatly.Api.Data;
using Vatly.Api.Models;

namespace Vatly.Api.Controllers;


[ApiController]
[Produces("application/json")]
[Route("api/v1/metar")]
public class MetarController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;
    
    public MetarController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [Route("{icao}", Name = "GetMetarByIcao")]
    public async Task<ActionResult<Metar>> GetMetar(string icao)
    {
        var metar = await dbContext.Metars.SingleOrDefaultAsync(m => m.Icao == icao.ToUpper());

        if (metar == null)
            return NotFound();

        return Ok(metar);
    }
}
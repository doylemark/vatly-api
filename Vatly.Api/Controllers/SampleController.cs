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
  private readonly JobsService jobsService;

  public SampleController(ApplicationDbContext dbContext, MetarService metarService, JobsService jobsService)
  {
    this.dbContext = dbContext;
    this.metarService = metarService;
    this.jobsService = jobsService;
  }
  
  [HttpGet]
  [Route("", Name = "GetMetar")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public string GetSample()
  {
    jobsService.StartJobs();
    return "hello";
  }
}
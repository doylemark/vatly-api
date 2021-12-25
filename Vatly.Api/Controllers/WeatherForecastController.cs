using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vatly.Api.Data;
using Vatly.Api.Models;

namespace Vatly.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var flights = new Flight()
        {
            Id = new Guid(),
            Callsign = "EIN124",
            Name = "Mark Doyle",
            Altitude = 33000,
            Heading = 120,
            Latitude = 53.6,
            Longitude = -3,
        };
        
        _dbContext.Flights.Add(flights);

        await _dbContext.SaveChangesAsync();
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vatly.Api.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Flight
{
    public Guid Id { get; set; }
    
    [Required]
    public string Cid { get; set; } = null!;
    
    [Required]
    public string Callsign { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public string Server { get; set; } = null!;

    [Required]
    public string Transponder { get; set; } = null!;
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public double Altitude { get; set; }
    
    public int Heading { get; set; }

    public FlightPlan? FlightPlan { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vatly.Api.Models.Responses;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class VatsimFlight
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

    public VatsimFlightPlan? FlightPlan { get; set; }

    [Required] public string LogonTime { get; set; } = null!;
}
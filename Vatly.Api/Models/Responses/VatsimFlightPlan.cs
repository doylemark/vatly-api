using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vatly.Api.Models.Responses;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class VatsimFlightPlan
{
    public Guid Id { get; set; }
    
    public Guid FlightId { get; set; }
    
    public string? FlightRules { get; set; }

    public string? AircraftShort { get; set; }

    public string? Departure { get; set; }

    public string? Arrival { get; set; }
    
    public string? Alternate { get; set; }

    public string? CruiseTas { get; set; }

    public string? Altitude { get; set; }

    public string? Deptime { get; set; }

    public string? EnrouteTime { get; set; }

    public string? FuelTime { get; set; }

    public string? Remarks { get; set; }

    public string? Route { get; set;}
    
    public string? AssignedTransponder { get; set; }
}
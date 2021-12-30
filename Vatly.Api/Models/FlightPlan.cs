namespace Vatly.Api.Models;

public class FlightPlan
{
    public Guid Id { get; set; }
    
    public Guid FlightId { get; set; }
    
    public string? Rules { get; set; }

    public string? Aircraft { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public string? Speed { get; set; }

    public string? Altitude { get; set; }

    public string? DepartureTime { get; set; }

    public string? EnrouteTime { get; set; }

    public string? FuelTime { get; set; }

    public string? Remarks { get; set; }

    public string? Route { get; set; }
}

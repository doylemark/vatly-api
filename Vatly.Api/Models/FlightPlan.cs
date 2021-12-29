namespace Vatly.Api.Models;

public class FlightPlan
{
    public Guid Id { get; set; }
    
    public Guid FlightId { get; set; }

    public string Rules { get; set; } = null!;

    public string Aircraft { get; set; } = null!;
    
    public Airport? Origin { get; set; }
    
    public Airport? Arrival { get; set; }

    public double Speed { get; set; } 
    
    public double Altitude { get; set; }

    public string DepartureTime { get; set; } = null!;

    public string EnrouteTime { get; set; } = null!;

    public string FuelTime { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public string Route { get; set; } = null!;
}

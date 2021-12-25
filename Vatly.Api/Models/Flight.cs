namespace Vatly.Api.Models;

public class Flight
{
    public Guid Id { get; set; }

    public string Callsign { get; set; } = null!;

    public string Name { get; set; } = null!;
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public double Altitude { get; set; }
    
    public int Heading { get; set; }
    
    public string? OriginIcao { get; set; }
    
    public string? DestinationIcao { get; set; }
    
    public string? Route { get; set; }
    
    public string? AircraftType { get; set; }
    
    public double? PlannedAltitude { get; set; }
    
    public string? Alternate { get; set; }
    
    public int? CruiseSpeed { get; set; }
}
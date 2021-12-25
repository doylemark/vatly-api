namespace Vatly.Api.Models;

public class Plan
{
    public string OriginIcao { get; set; } = null!;
    
    public string DestinationIcao { get; set; } = null!;
    
    public string Route { get; set; } = null!;
    
    public string AircraftType { get; set; } = null!;
    
    public double Altitude { get; set; }
    
    public string Alternate { get; set; } = null!;
    
    public int CruiseSpeed { get; set; }
}
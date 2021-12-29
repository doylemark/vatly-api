using System.ComponentModel.DataAnnotations;

namespace Vatly.Api.Models;

public class Airport
{
    public Guid Id { get; set; }
    
    [Required]
    public string Icao { get; set; } = null!;

    public string Iata { get; set; } = null!;

    [Required] 
    public string Name { get; set; } = null!;
    
    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;
    
    public int Elevation { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }

    [Required] 
    public string TimeZone { get; set; } = null!;
}
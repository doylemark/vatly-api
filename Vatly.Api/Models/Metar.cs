using System.ComponentModel.DataAnnotations;

namespace Vatly.Api.Models;

public class Metar
{
    public Guid Id { get; set; }

    [Required]
    public string RawText { get; set; } = null!;

    [Required]
    public string Icao { get; set; } = null!;
    
    public DateTime Date { get; set; }
    
    public double Temperature { get; set; }
    
    public double DewPoint { get; set; }
    
    public int WindDirection { get; set; }
    
    public int WindSpeed { get; set; }
    
    public double Pressure { get; set; }
    
    public double? WindGust { get; set; }
    
    public double? Visibility { get; set; }
}
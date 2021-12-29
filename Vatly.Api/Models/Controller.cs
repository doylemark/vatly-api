namespace Vatly.Api.Models;

public class Controller
{
    public Guid Id { get; set; }

    public int Cid { get; set; }

    public string Name { get; set; } = null!;
    
    public string Callsign { get; set; } = null!;
    
    public string Frequency { get; set; } = null!;
    
    public int Facility { get; set; }
    
    public int Rating { get; set; }
    
    public string Server { get; set; } = null!;
    
    public int VisualRange { get; set; }
    
    public string LogonTime { get; set; } = null!;
}
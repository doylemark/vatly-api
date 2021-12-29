using System.Globalization;
using CsvHelper;
using Vatly.Api.Models;

namespace Vatly.Api.Factories;

public static class AirportsFactory
{
    public static async Task<List<Airport>> LoadAirports()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "airports.csv");
        var fileStream = File.OpenRead(path);
        var reader = new StreamReader(fileStream);
        var parser = new CsvParser(reader, CultureInfo.InvariantCulture);

        var airports = new List<Airport>();
        
        while (await parser.ReadAsync())
        {
            var parts = parser.Record;

            var airport = ParseAirport(parts);
            
            airports.Add(airport);
        }

        return airports;
    }

    private static Airport ParseAirport(string[] parts)
    {

        int.TryParse(parts[6], out var elevation);
        double.TryParse(parts[7], out var latitude);
        double.TryParse(parts[8], out var longitude);

        return new Airport()
        {
            Icao = parts[0],
            Iata = parts[1],
            Name = parts[2],
            City = parts[3],
            Region = parts[4],
            Country = parts[5],
            Elevation = elevation,
            Latitude = latitude,
            Longitude = longitude,
            TimeZone = parts[9],
        };
    }
}
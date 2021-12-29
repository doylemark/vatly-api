using System.Globalization;
using Vatly.Api.Data;
using Vatly.Api.Models;
using System.IO.Compression;
using CsvHelper;
using Microsoft.EntityFrameworkCore;

namespace Vatly.Api.Services;

public class MetarService
{
    private readonly string metarUrl = "https://www.aviationweather.gov/adds/dataserver_current/current/metars.cache.csv.gz";

    private readonly ApplicationDbContext dbContext;
    private readonly IHttpClientFactory httpClientFactory;

    public MetarService(
        ApplicationDbContext dbContext, 
        IHttpClientFactory httpClientFactory)
    {
        this.dbContext = dbContext;
        this.httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// 1. Fetch all new metars and check if they exist in the DB.
    ///      if a metar exists and new metar is more recent: update
    ///      if not: add it
    /// 2. Select all metars older than an hour and delete them all
    /// 3. Print what operations have occured
    /// </summary>
    public async Task UpdateMetars()
    {
        var currentMetars = await dbContext.Metars.ToListAsync();
        var newMetars = await FetchMetars();
        int metarsAdded = 0;
        int metarsRemoved = 0;
        int noChange = 0;

        foreach (var metar in newMetars.Take(3))
        {
            var existingMetar = currentMetars.Find(m => m.Icao == metar.Icao);

            if (existingMetar == null)
            {
                await dbContext.Metars.AddAsync(metar);
                metarsAdded++;
            }
            else if (DateTime.Compare(metar.Date, existingMetar.Date) > 0)
            {
                dbContext.Remove(existingMetar);
                dbContext.Metars.Add(metar);
                metarsAdded++;
                metarsRemoved++;
            }
            else
            {
                noChange++;
            }
            
            await dbContext.SaveChangesAsync();
        }

        Console.WriteLine($"Wrote {metarsAdded} new metars, removed {metarsRemoved}, {noChange} were unchanged");
    }

    public async Task RemoveExpiredMetars()
    {
        var currentMetars = await dbContext.Metars.ToListAsync();

        int removed = 0;
        var maxAge = DateTime.UtcNow.AddHours(-1);
        
        foreach (var metar in currentMetars) 
        {
            if (DateTime.Compare(maxAge, metar.Date) > 1)
            {
                dbContext.Remove(metar);
                removed++;
            }
        }

        Console.WriteLine($"Removed {removed}, left ${currentMetars.Count}");
    }

    private async Task<List<Metar>> FetchMetars()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            this.metarUrl
        );

        var httpClient = httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        var stream = httpResponseMessage.Content.ReadAsStreamAsync().Result;

        var gZipStream = new GZipStream(stream, CompressionMode.Decompress);
        var csvStream = new StreamReader(gZipStream);
        var parser = new CsvParser(csvStream, CultureInfo.InvariantCulture);

        var metars = new List<Metar>();

        while (await parser.ReadAsync())
        {
            var parts = parser.Record;

            if (parts == null || parts.Length == 1 || parts[0] == "raw_text")
                continue;

            var metar = ParseMetarCsv(parts);
            
            metars.Add(metar);
        }
        return metars;
    }

    private static Metar ParseMetarCsv(string[] parts)
    {
        if (!DateTime.TryParse(parts[2], out DateTime date))
            date = DateTime.UtcNow;

        double.TryParse(parts[5], out var temperature);
        double.TryParse(parts[6], out var dewPoint);
        int.TryParse(parts[7], out var windDirection);
        int.TryParse(parts[8], out var windSpeed);
        int.TryParse(parts[9], out var windGust);
        double.TryParse(parts[10], out var visibility);
        double.TryParse(parts[11], out var pressureInHg);

        var metar = new Metar()
        {
            Id = new Guid(),
            RawText = parts[0].Trim(),
            Icao = parts[1].ToUpper(),
            Date = date,
            Temperature = temperature,
            DewPoint = dewPoint,
            WindDirection = windDirection,
            WindSpeed = windSpeed,
            WindGust = windGust,
            Pressure = Math.Round(pressureInHg * 33.86),
            Visibility = visibility
        };

        return metar;
    }
}
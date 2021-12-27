using System.Globalization;
using Vatly.Api.Data;
using Vatly.Api.Models;
using System.IO.Compression;
using AutoMapper;
using CsvHelper;

namespace Vatly.Api.Services;

public class MetarService
{
    private readonly string metarUrl = "https://www.aviationweather.gov/adds/dataserver_current/current/metars.cache.csv.gz";

    private readonly ApplicationDbContext dbContext;
    private readonly IHttpClientFactory httpClientFactory;
    private readonly IMapper mapper;

    public MetarService(
        ApplicationDbContext dbContext, 
        IHttpClientFactory httpClientFactory,
        IMapper mapper)
    {
        this.dbContext = dbContext;
        this.httpClientFactory = httpClientFactory;
        this.mapper = mapper;
    }

    public async void UpdateMetars()
    {
        var newMetars = await FetchMetars();
        
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
            Icao = parts[1],
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
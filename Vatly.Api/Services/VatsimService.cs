
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vatly.Api.Data;
using Vatly.Api.Models;
using Vatly.Api.Models.Responses;

namespace Vatly.Api.Services;

public class VatsimService
{
    private readonly string vatsimUrl = "https://data.vatsim.net/v3/vatsim-data.json";

    private readonly IHttpClientFactory httpClientFactory;
    private readonly ApplicationDbContext dbContext;
    private readonly IMapper mapper;

    public VatsimService(IHttpClientFactory httpClientFactory, ApplicationDbContext dbContext, IMapper mapper)
    {
        this.httpClientFactory = httpClientFactory;
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    public async Task UpdateData()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            vatsimUrl
        );

        var httpClient = httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        var result = await httpResponseMessage.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<VatsimApiResponse>(result);

        await UpdateFlights(data.Pilots);
    }

    private async Task UpdateFlights(List<VatsimFlight> flights)
    {
        await dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE \"Flights\" CASCADE");

        foreach (var flight in flights)
        {
            var newFlight = mapper.Map<Flight>(flight);

            if (newFlight != null)
                dbContext.Flights.Add(newFlight);
        }

        Console.Write(dbContext.Flights.Count());
        await dbContext.SaveChangesAsync();
    }
    
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public partial class VatsimApiResponse
    {
        public List<VatsimFlight> Pilots { get; set; } = null!;

        public List<Controller> Controllers { get; set; } = null!;

        public List<Controller> Atis { get; set; } = null!;
    }
}
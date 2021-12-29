using Vatly.Api.Factories;

namespace Vatly.Api.Data;

public class ApplicationDbSeeder
{
    private readonly ApplicationDbContext dbContext;

    public ApplicationDbSeeder(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task SeedDb()
    {
        await SeedAirports();
    }

    private async Task SeedAirports()
    {
        var count = dbContext.Airports.Count();

        Console.WriteLine($"count:{count}");
        if (count != 0)
            return;

        var airports = await AirportsFactory.LoadAirports();

        foreach (var airport in airports)
        {
            dbContext.Airports.Add(airport);
        }

        await dbContext.SaveChangesAsync();
    }
}
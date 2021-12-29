using Microsoft.EntityFrameworkCore;
using Vatly.Api.Models;

namespace Vatly.Api.Data;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<Metar> Metars { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;
}
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Vatly.Api.Data;
using Vatly.Api.Services;

var corsDomains = new []
{
    "http://localhost:8081",
    "http://localhost:5001",
};

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>((sp, opt) =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDb"), acts =>
    {
        acts.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null!);
    });
    opt.UseInternalServiceProvider(sp);
});

builder.Services.AddHangfire(configuration =>
{
    configuration.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("ApplicationDb"));
});
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SchemaFilter<RequireValueTypePropertiesSchemaFilter>();
});
builder.Services.AddEntityFrameworkNpgsql();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins(corsDomains)
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader();
    });
});

builder.Services.AddScoped<MetarService>();
builder.Services.AddTransient<JobsService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    opt.RoutePrefix = string.Empty;
});
app.UseHangfireDashboard("/jobs");

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var jobs = services.GetService<JobsService>();
    jobs?.StartJobs();
}

app.Run();

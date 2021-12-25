using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Vatly.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql();
builder.Services.AddDbContext<ApplicationDbContext>((sp, opt) =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDb"), acts =>
    {
        acts.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null!);
    });
});

builder.Services.AddHangfire(configuration =>
{
    configuration.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("ApplicationDb"));
});
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opts.RoutePrefix = string.Empty;

    });
    app.UseHangfireDashboard("/jobs");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
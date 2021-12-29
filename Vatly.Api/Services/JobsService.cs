using Hangfire;

namespace Vatly.Api.Services;

public class JobsService
{
    private readonly MetarService metarService;

    public JobsService(MetarService metarService)
    {
        this.metarService = metarService;
    }

    public void StartJobs()
    {
        Console.Write("Started Recurring Jobs");

        // Every 10 minutes
        RecurringJob.AddOrUpdate("updateMetars", () => metarService.UpdateMetars(), "*/10 * * * *");
        RecurringJob.AddOrUpdate("expireMetars", () => metarService.RemoveExpiredMetars(), Cron.Hourly);
    }
}
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
        RecurringJob.AddOrUpdate("updateMetars", () => metarService.UpdateMetars(), Cron.Minutely);
    }
}
using Hangfire;

namespace Vatly.Api.Services;

public class JobsService
{
    private readonly MetarService metarService;
    private readonly VatsimService vatsimService;

    public JobsService(MetarService metarService, VatsimService vatsimService)
    {
        this.metarService = metarService;
        this.vatsimService = vatsimService;
    }

    public async Task StartJobs()
    {
        Console.Write("Started Recurring Jobs");

        await vatsimService.UpdateData();

        RecurringJob.AddOrUpdate("updateMetars", () => metarService.UpdateMetars(), "*/10 * * * *");
        RecurringJob.AddOrUpdate("expireMetars", () => metarService.RemoveExpiredMetars(), Cron.Hourly);
        // RecurringJob.AddOrUpdate("updateVatsim", () => vatsimService.UpdateData(), Cron.Minutely);
    }
}
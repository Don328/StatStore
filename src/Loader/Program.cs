using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core;
using StatStore.Loader.Core.Data;
using StatStore.Loader.Core.Data.Fixtures.Scheduler;
using StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces;
using StatStore.Loader.Core.Data.Fixtures.SportsDataIO;
using StatStore.Loader.Core.Data.Fixtures.SportsDataIO.Interfaces;
using StatStore.Loader.Core.Data.Interfaces;
using StatStore.Loader.Core.Data.Loaders.DataLoaders;
using StatStore.Loader.Core.Data.Loaders.DataLoaders.Interfaces;
using StatStore.Loader.Core.Data.Loaders.ScheduleLoaders;
using StatStore.Loader.Core.Data.Loaders.ScheduleLoaders.Interfaces;
using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Models;
using StatStore.Loader.Core.Services;
using StatStore.Loader.Core.Services.Interfaces;
using StatStore.Loader.SportsDataIO;
using StatStore.Loader.SportsDataIO.Endpoints;
using StatStore.Loader.SportsDataIO.Endpoints.Interfaces;
using StatStore.Loader.SportsDataIO.Interfaces;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader;

public class program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddSingleton<program>();
        builder.Services.AddSingleton<StateStore>();

        builder.Services.AddDbContextPool<AppDataContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("statstore"),
                new MySqlServerVersion(new Version(10, 5, 13))));

        builder.Services.AddDbContextPool<AppScheduleContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("schedule"),
                new MySqlServerVersion(new Version(10, 5, 13))));

        builder.Services.AddTransient<IGenericDataRepo<TimeFrame>, PayloadRepo<TimeFrame>>();
        builder.Services.AddTransient<IGenericDataRepo<LoadRecord>, SchedulerRepo<LoadRecord>>();
        builder.Services.AddTransient<ICustomHttpClient, SportsDataIOHttpClient>();
        builder.Services.AddTransient<IStateLoader, StateLoader>();
        builder.Services.AddTransient<IFetchTimeFrame, TimeFrameEndpoint>();
        builder.Services.AddTransient<ITimeFrameFixture, TimeFrameFixture>();
        builder.Services.AddTransient<ILoadTimeFrame, TimeFrameLoader>();
        builder.Services.AddTransient<ILoadRecords, RecordLoader>();
        builder.Services.AddTransient<ILoadRecordFixture, LoadRecordFixture>();

        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        await app.Services.GetRequiredService<program>().Run(builder.Services, app);
        await app.StopAsync();
    }

    public async Task Run(IServiceCollection services, WebApplication app)
    {
        StateLoader loader = services.BuildServiceProvider()
            .GetRequiredService<StateLoader>();
        await loader.Initialize();

        RequestQueue queue = (RequestQueue)services.BuildServiceProvider()
            .GetRequiredService<IQueueRequests>();
        Parallel.Invoke(() => queue.StartAsync().GetAwaiter());

        await app.RunAsync();
    }
}

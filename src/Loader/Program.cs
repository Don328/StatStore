using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core;
using StatStore.Loader.Core.Interfaces;

namespace StatStore.Loader;

public class program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ServiceCollectionLoader.AddCoreServices(builder.Services);

        ServiceCollectionLoader.AddScheduleDb(
            builder.Services,
            builder.Configuration
                .GetConnectionString("schedule"));

        ServiceCollectionLoader.AddSportsDataDb(
            builder.Services,
            builder.Configuration
                .GetConnectionString("statStore"));

        ServiceCollectionLoader.AddEndPoints(builder.Services);
        ServiceCollectionLoader.AddDataLoaders(builder.Services);
        ServiceCollectionLoader.AddDbFixtures(builder.Services);

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
        RequestQueue queue = (RequestQueue)services.BuildServiceProvider()
            .GetRequiredService<IQueueRequests>();
        Parallel.Invoke(() => queue.StartAsync().GetAwaiter());

        await app.RunAsync();
    }
}

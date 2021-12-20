using Microsoft.EntityFrameworkCore;

namespace StatStore.Loader;

public class program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddSingleton<program>();

        builder.Services.AddDbContextPool<AppDbContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("statstore"),
                new MySqlServerVersion(new Version(10, 5, 13))));

        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
        await app.RunAsync();
    }
}

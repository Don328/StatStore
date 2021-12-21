using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using StatStore.Loader.Core.SchemaFactories.SportsData;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options) { }

    public DbSet<TimeFrame> CurrentTimeFrame { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        TimeFrameSchema.OnModelCreating(builder);
    }
}
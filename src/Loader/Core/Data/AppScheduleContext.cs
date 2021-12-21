using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using StatStore.Loader.Core.SchemaFactories.Scheduler;

namespace StatStore.Loader.Core.Data;

public class AppScheduleContext : DbContext
{
    public AppScheduleContext(DbContextOptions<AppScheduleContext> options)
        : base(options) { }

    public DbSet<LoadRecord> LoadRecord { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        LoadRecordSchema.OnModelCreating(builder);
    }
}

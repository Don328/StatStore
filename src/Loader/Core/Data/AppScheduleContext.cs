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
        builder.Entity<LoadRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedNever();
            entity.Property(e => e.LastLoad);
            entity.Property(e => e.LastUpdate);
            entity.Property(e => e.TimeFrameLoaded);

            entity.HasData(new LoadRecord
            {
                Id = 1,
                LastLoad = DateTime.MinValue,
                LastUpdate = DateTime.MinValue,
                TimeFrameLoaded = DateTime.MinValue,
            });
        });
    }
}

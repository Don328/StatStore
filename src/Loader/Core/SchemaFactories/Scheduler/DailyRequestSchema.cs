using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using static StatStore.Loader.SportsDataIO.Constants;

namespace StatStore.Loader.Core.SchemaFactories.Scheduler
{
    internal static class DailyRequestSchema
    {
        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScheduledRequest.Daily>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.ExecuteAt);

                entity.HasData(
                    new ScheduledRequest.Daily
                    {
                        Id = 2,
                        Tag = $"{RequestTag.schedules}",
                        ExecuteAt = new(2, 0, 1)
                    });
            });
        }
    }
}

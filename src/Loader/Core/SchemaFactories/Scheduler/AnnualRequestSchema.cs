using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using static StatStore.Loader.SportsDataIO.Constants;

namespace StatStore.Loader.Core.SchemaFactories.Scheduler
{
    internal static class AnnualRequestSchema
    {
        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScheduledRequest.Annual>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.ExecuteAt);

                entity.HasData(new ScheduledRequest.Annual
                {
                    Id = 1,
                    Tag = $"{RequestTag.timeframe}",
                    ExecuteAt = new(3, 0, 0),
                    Month = 7,
                    DayOfMonth = 1
                });
            });
        }
    }
}

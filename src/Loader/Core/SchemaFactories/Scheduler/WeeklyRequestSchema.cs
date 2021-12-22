using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using static StatStore.Loader.SportsDataIO.Constants;

namespace StatStore.Loader.Core.SchemaFactories.Scheduler
{
    internal static class WeeklyRequestSchema
    {
        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScheduledRequest.Weekly>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Day);

                entity.HasData(
                    new ScheduledRequest.Weekly
                    {
                        Id = 1,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Thursday,
                        ExecuteAt = new(22, 0, 0)
                    },
                    new ScheduledRequest.Weekly
                    {
                        Id = 2,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Friday,
                        ExecuteAt = new(8, 0, 0)
                    },
                    new ScheduledRequest.Weekly
                    {
                        Id = 3,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Sunday,
                        ExecuteAt = new(14, 0, 0)
                    },
                    new ScheduledRequest.Weekly
                    {
                        Id = 4,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Sunday,
                        ExecuteAt = new(17, 0, 0)
                    },
                    new ScheduledRequest.Weekly
                    {
                        Id = 5,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Sunday,
                        ExecuteAt = new(22, 0, 0)
                    },
                    new ScheduledRequest.Weekly
                    {
                        Id = 6,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Monday,
                        ExecuteAt = new(8, 0, 0)
                    },
                    new ScheduledRequest.Weekly
                    {
                        Id = 7,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Monday,
                        ExecuteAt = new(22, 0, 0)
                    });
            });
        }
    }
}

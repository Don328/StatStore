using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using static StatStore.Loader.SportsDataIO.Constants;

namespace StatStore.Loader.Core.SchemaFactories.Scheduler
{
    internal static class WeeklySpanRequestSchema
    {
        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScheduledRequest.WeeklySpan>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Day);

                entity.HasData(
                    new ScheduledRequest.WeeklySpan
                    {
                        Id = 8,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Thursday,
                        ExecuteAt = new(17, 30, 0),
                        Frequency = new(0, 10, 0),
                        Durration = new(3, 0, 0)
                    },
                    new ScheduledRequest.WeeklySpan
                    {
                        Id = 9,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Sunday,
                        ExecuteAt = new(10, 0, 0),
                        Frequency = new(0, 10, 0),
                        Durration = new(6, 30, 0)
                    },
                    new ScheduledRequest.WeeklySpan
                    {
                        Id = 10,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Sunday,
                        ExecuteAt = new(17, 30, 0),
                        Frequency = new(0, 10, 0),
                        Durration = new(3, 0, 0)
                    },
                    new ScheduledRequest.WeeklySpan
                    {
                        Id = 11,
                        Tag = $"{RequestTag.scoresByWeek}",
                        Day = DayOfWeek.Monday,
                        ExecuteAt = new(17, 30, 0),
                        Frequency = new(0, 10, 0),
                        Durration = new(3, 0, 0)
                    });
            });
        }
    }
}

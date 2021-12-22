using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using StatStore.Loader.Core.SchemaFactories.Scheduler;

namespace StatStore.Loader.Core.Data;

public class AppScheduleContext : DbContext
{
    public AppScheduleContext(DbContextOptions<AppScheduleContext> options)
        : base(options) { }

    public DbSet<LoadRecord> LoadRecord { get; set; }
    public DbSet<ScheduledRequest.Queued> QueuedRequests { get; set; }
    public DbSet<ScheduledRequest.Annual> AnnualRequests { get; set; }
    public DbSet<ScheduledRequest.Daily> DailyRequests { get; set; }
    public DbSet<ScheduledRequest.Monthly> MonthlyRequests { get; set; }
    public DbSet<ScheduledRequest.Oneoff> OneoffRequests { get; set; }
    public DbSet<ScheduledRequest.OneoffSpan> OneoffSpanRequests { get; set; }
    public DbSet<ScheduledRequest.Weekly> WeeklyRequests { get; set; }
    public DbSet<ScheduledRequest.WeeklySpan> WeeklySpanRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        LoadRecordSchema.OnModelCreating(builder);
        RequestQueueSchema.OnModelCreating(builder);
        AnnualRequestSchema.OnModelCreating(builder);
        DailyRequestSchema.OnModelCreating(builder);
        MonthlyRequestSchema.OnModelCreating(builder);
        OneoffRequestSchema.OnModelCreating(builder);
        OneOffSpanRequestSchema.OnModelCreating(builder);
        WeeklyRequestSchema.OnModelCreating(builder);
        WeeklySpanRequestSchema.OnModelCreating(builder);
    }
}

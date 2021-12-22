using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.SchemaFactories.Scheduler
{
    internal static class RequestQueueSchema
    {
        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScheduledRequest.Queued>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.HasIndex(e => e.ExecuteAt);
                entity.HasIndex(e => e.IsCompleted);
            });
        }
    }
}

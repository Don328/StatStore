using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.SchemaFactories.Scheduler
{
    internal static class OneoffRequestSchema
    {
        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScheduledRequest.Oneoff>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

            });
        }
    }
}

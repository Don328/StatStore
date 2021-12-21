using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.SchemaFactories.Scheduler
{
    internal static class LoadRecordSchema
    {
        internal static void OnModelCreating(ModelBuilder builder)
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
}

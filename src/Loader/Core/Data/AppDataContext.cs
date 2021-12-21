using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options) { }

    public DbSet<TimeFrame> CurrentTimeFrame { get; set; }
    public DbSet<TestModel> TestModels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TestModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);

                entity.HasData(
                    new TestModel
                    {
                        Id = -1,
                        Name = "Test Model",
                    });
            });

        builder.Entity<TimeFrame>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedNever();
            entity.Property(e => e.SeasonType);
            entity.Property(e => e.Season);
            entity.Property(e => e.Week);
            entity.Property(e => e.Name);
            entity.Property(e => e.ShortName);
            entity.Property(e => e.StartDate);
            entity.Property(e => e.EndDate);
            entity.Property(e => e.FirstGameStart);
            entity.Property(e => e.FirstGameEnd);
            entity.Property(e => e.LastGameEnd);
            entity.Property(e => e.HasGames);
            entity.Property(e => e.HasStarted);
            entity.Property(e => e.HasEnded);
            entity.Property(e => e.HasFirstGameStarted);
            entity.Property(e => e.HasFirstGameEnded);
            entity.Property(e => e.HasLastGameEnded);
            entity.Property(e => e.ApiSeason);
            entity.Property(e => e.ApiWeek);
        });

    }
}
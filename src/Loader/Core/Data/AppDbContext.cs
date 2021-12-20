using Microsoft.EntityFrameworkCore;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

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

    }
}
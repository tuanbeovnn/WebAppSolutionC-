using IntegrationModels.WeatherInfo;
using Microsoft.EntityFrameworkCore;

namespace IntegrationApplication.EF;

public class IntegrationDbContext : DbContext
{
    public IntegrationDbContext()
    {
    }


    public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options)
    {
    }

    public virtual DbSet<WeatherInfoEntity> WeatherInfo { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=code4fun.xyz,1433;Database=blogs_solution;User Id=sa;Password=P@ssword*123;";

            optionsBuilder.UseSqlServer(connectionString, options => { options.EnableRetryOnFailure(); });
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherInfoEntity>(e =>
        {
            e.HasKey(m => m.Id);
            e.Property(e => e.city).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
using Biogenom.Model.Entity;
using Biogenom.Model.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Biogenum.SqlServer.DbContext;

public class BiogenomDbContext(DbContextOptions<BiogenomDbContext> options)
    : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<NutrientStandard> NutrientStandards { get; set; }
    public DbSet<NutritionSource> NutritionSources { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<UserNutrientLog> UserNutrientLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.HasDefaultSchema("biogenom");
        modelBuilder.ApplyConfiguration(new NutrientConfiguration());
        modelBuilder.ApplyConfiguration(new NutrientStandardConfiguration());
        modelBuilder.ApplyConfiguration(new NutritionSourceConfiguration());
        modelBuilder.ApplyConfiguration(new UnitConfiguration());
        modelBuilder.ApplyConfiguration(new UserNutrientLogConfiguration());
    }
}
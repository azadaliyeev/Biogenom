using Biogenom.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Model.EntityConfigurations;

public class NutrientStandardConfiguration : IEntityTypeConfiguration<NutrientStandard>
{
    public void Configure(EntityTypeBuilder<NutrientStandard> builder)
    {
        builder.ToTable("nutrients_standards");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.MinNorm).HasColumnName("min_norm").HasColumnType("numeric(10,2)");
        builder.Property(x => x.MaxNorm).HasColumnName("max_norm").HasColumnType("numeric(10,2)");
        builder.Property(x => x.RecommendedValue).HasColumnName("recommended_value").HasColumnType("numeric(10,2)");
        builder.Property(x => x.IsInRange).HasColumnName("is_in_range").IsRequired().HasDefaultValue(false);
    }
}
using Biogenom.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Model.EntityConfigurations;

public class NutritionSourceConfiguration : IEntityTypeConfiguration<NutritionSource>
{
    public void Configure(EntityTypeBuilder<NutritionSource> builder)
    {
        builder.ToTable("nutrition_source");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CurrentNutrition).HasColumnName("current_nutrition").HasColumnType("numeric(10,2)");
        builder.Property(x => x.SupplementNutrition).HasColumnName("supplement_nutrition")
            .HasColumnType("numeric(10,2)");
        builder.Property(x => x.FoodNutrition).HasColumnName("food_nutrition").HasColumnType("numeric(10,2)");
        builder.Property(x => x.IsDelete).HasColumnName("is_delete").HasDefaultValue(false);
    }
}
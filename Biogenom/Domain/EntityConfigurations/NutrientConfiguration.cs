using Biogenom.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Model.EntityConfigurations;

public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
{
    public void Configure(EntityTypeBuilder<Nutrient> builder)
    {
        builder.ToTable("nutrients");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(10).IsRequired();
        builder.Property(x => x.ScientificName).HasColumnName("scientific_name").HasMaxLength(15);

        builder.Property(x => x.UnitId).HasColumnName("unit_id").IsRequired();
        builder.HasOne(x => x.Unit)
            .WithMany(u => u.Nutrients)
            .HasForeignKey(x => x.UnitId)
            .HasConstraintName("fk_vitamins_units");

        builder.Property(x => x.NutrientsId).HasColumnName("nutrients_id").IsRequired();
        builder.HasOne(x => x.NutrientStandard)
            .WithMany(ns => ns.Nutrients)
            .HasForeignKey(x => x.NutrientsId)
            .HasConstraintName("fk_nutrients_standart");
    }
}
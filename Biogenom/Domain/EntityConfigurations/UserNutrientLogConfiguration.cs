using Biogenom.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Model.EntityConfigurations;

public class UserNutrientLogConfiguration : IEntityTypeConfiguration<UserNutrientLog>
{
    public void Configure(EntityTypeBuilder<UserNutrientLog> builder)
    {
        builder.ToTable("user_nutrient_log");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.NutritionSourceId).HasColumnName("nutrition_source_id").IsRequired();
        builder.HasOne(x => x.NutritionSource)
            .WithMany(ns => ns.UserNutrientLogs)
            .HasForeignKey(x => x.NutritionSourceId)
            .HasConstraintName("fk_nsn_nutrition");

        builder.Property(x => x.NutrientId).HasColumnName("nutrient_id").IsRequired();
        builder.HasOne(x => x.Nutrient)
            .WithMany(n => n.UserNutrientLogs)
            .HasForeignKey(x => x.NutrientId)
            .HasConstraintName("fk_nsn_nutrient");

        builder.Property(x => x.UserId).HasColumnName("user_id").HasMaxLength(200).IsRequired();
        builder.Property(x => x.CreateDate).HasColumnName("create_date");

        builder.HasIndex(x => new { x.NutritionSourceId, x.NutrientId }).IsUnique();
    }
}
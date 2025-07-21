
namespace AspNetCoreArchTemplate.Data.Configuration
{
    using EatHealthy.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DayMealConfiguration : IEntityTypeConfiguration<DayMeal>
    {
        public void Configure(EntityTypeBuilder<DayMeal> builder)
        {
            builder.HasKey(dm => new { dm.DayId, dm.MealId });

            builder.HasOne(dm => dm.Day)
                .WithMany(d => d.DayMeals)
                .HasForeignKey(dm => dm.DayId);

            builder.HasOne(dm => dm.Meal)
                .WithMany(m => m.DayMeals)
                .HasForeignKey(dm => dm.MealId);

            builder.ToTable("DayMeals")
                .HasComment("Links a Meal to a Day, allowing reuse across days");
        }
    }
}


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
        public void Configure(EntityTypeBuilder<DayMeal> entity)
        {
            entity.HasKey(dm => new { dm.DayId, dm.MealId });

            entity.HasOne(dm => dm.Day)
                .WithMany(d => d.DayMeals)
                .HasForeignKey(dm => dm.DayId);

            entity.HasOne(dm => dm.Meal)
                .WithMany(m => m.DayMeals)
                .HasForeignKey(dm => dm.MealId);

            entity.ToTable("DayMeals")
                .HasComment("Links a Meal to a Day, allowing reuse across days");
        }
    }
}

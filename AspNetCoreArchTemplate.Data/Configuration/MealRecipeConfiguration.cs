

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
    public class MealRecipeConfiguration : IEntityTypeConfiguration<MealRecipe>
    {
        public void Configure(EntityTypeBuilder<MealRecipe> builder)
        {
            builder.HasKey(mr => new { mr.MealId, mr.RecipeId });

            builder.HasOne(mr => mr.Meal)
                .WithMany(m => m.MealRecipes)
                .HasForeignKey(mr => mr.MealId);

            builder.HasOne(mr => mr.Recipe)
                .WithMany(r => r.MealRecipes)
                .HasForeignKey(mr => mr.RecipeId);

            builder.ToTable("MealRecipes")
                .HasComment("Links a Recipe to a Meal");
        }
    }

}

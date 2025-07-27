

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
    using static EatHealthy.Data.Common.EntityConsts.Meal;
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> entity)
        {
            entity.HasKey(m => m.Id);

            entity.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity.Property(m => m.Note)
                .HasMaxLength(NoteMaxLength);

            entity.HasOne(d => d.CreatedByUser)
                  .WithMany(u => u.Meals)
                  .HasForeignKey(d => d.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            entity.Property(p => p.IsDeleted)
              .HasDefaultValue(false);

            entity.ToTable("Meals")
                .HasComment("A specific meal in a day (e.g., breakfast, lunch, dinner)");

           
        }
    }
}



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
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(m => m.Note)
                .HasMaxLength(NoteMaxLength);

            builder.Property(m => m.TimeEaten);

            builder.ToTable("Meals")
                .HasComment("A specific meal in a day (e.g., breakfast, lunch, dinner)");
        }
    }
}

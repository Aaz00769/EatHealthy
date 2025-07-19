

namespace EatHealthy.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Common.EntityConsts.Recipie;
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(r => r.Description)
                .HasMaxLength(DescriptionLenght);

            builder
                .Property(r => r.IsPublic)
                .IsRequired();

            builder
                .Property(r => r.IsApprovedByAdmin)
                .IsRequired();

            builder
                .Property(r => r.CreatedOn)
                .IsRequired();

            builder
                .Property(r => r.ModifiedOn);

            builder
                .ToTable("Recipes")
                .HasComment("User-created recipe");
        }
    }
}


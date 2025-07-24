

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
        public void Configure(EntityTypeBuilder<Recipe> entity)
        {
            entity
                .HasKey(r => r.Id);

            entity
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(r => r.Description)
                .HasMaxLength(DescriptionLenght);

            entity
                .Property(r => r.IsPublic);



            entity
                .Property(r => r.IsApprovedByAdmin);
               

            entity
                .Property(r => r.CreatedOn);
                

            entity
                .Property(r => r.ModifiedOn);

            entity
                .ToTable("Recipes")
                .HasComment("User-created recipe");

            entity.Property(p => p.IsDeleted)
              .HasDefaultValue(false);
             

        }
    }
}


﻿

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
    using static Common.EntityConsts.RecipeProduct;
    public class RecipeProductConfiguration : IEntityTypeConfiguration<RecipeProduct>
    {
        public void Configure(EntityTypeBuilder<RecipeProduct> entity)
        {
            entity.HasKey(rp => rp.Id);

            entity
                .Property(rp => rp.Grams)
              
                .HasComment("Amount of the product in grams");

            entity
                .Property(rp => rp.Note)
                .HasMaxLength(NoteMaxLength)
                .HasComment("Optional note about the product");

            entity
                .HasOne(rp => rp.Recipe)
                .WithMany(r => r.RecipeProducts)
                .HasForeignKey(rp => rp.RecipeId);
            entity
                .HasOne(rp => rp.Product)
                .WithMany(p => p.RecipeProducts)
                .HasForeignKey(rp => rp.ProductId);

            entity
                .ToTable("RecipeProducts")
                .HasComment("Links a Product to a Recipe with a specific amount");

            entity.Property(rp => rp.ModifiedOn).IsConcurrencyToken();
        }
    }
}


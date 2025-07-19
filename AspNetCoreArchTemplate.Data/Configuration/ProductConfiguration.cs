

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
    using static Common.EntityConsts.Product;
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(p => p.Calories)
                .IsRequired();

            entity
                .Property(p => p.Proteins);

            entity
                .Property(p => p.Fats);

            entity
                .Property(p => p.Carbohydrates);

            entity
                .Property(p => p.ServingSizeGrams);


        }
    }
}


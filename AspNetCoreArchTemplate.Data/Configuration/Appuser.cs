using EatHealthy.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(u => u.Days)
                   .WithOne(d => d.CreatedByUser)
                   .HasForeignKey(d => d.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Meals)
                   .WithOne(m => m.CreatedByUser)
                   .HasForeignKey(m => m.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Recipes)
                   .WithOne(r => r.CreatedByUser)
                   .HasForeignKey(r => r.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.ProfileCompleted)
           .IsRequired()
           .HasDefaultValue(false);

           
        }
    }
}

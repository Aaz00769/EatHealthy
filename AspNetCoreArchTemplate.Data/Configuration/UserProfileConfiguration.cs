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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Age)
                .IsRequired();

            builder.Property(p => p.Height)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(p => p.Weight)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.ActivityLevel)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.Goal)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.DailyCalorieTarget)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationship with AppUser
            builder.HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<UserProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


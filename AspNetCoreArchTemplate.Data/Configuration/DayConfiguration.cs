﻿

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
    using static EatHealthy.Data.Common.EntityConsts.Day;
    public class DayConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> entity)
        {
            entity.HasKey(d => d.Id);

            entity.Property(d => d.Date);
               

            entity.Property(d => d.Note)
                .HasMaxLength(NoteMaxLength);

           

            entity.HasOne(d => d.CreatedByUser)
                  .WithMany(u => u.Days)
                  .HasForeignKey(d => d.CreatedByUserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.Property(p => p.IsDeleted)
              .HasDefaultValue(false);

            entity.ToTable("Days")
                .HasComment("Represents a user's day which contains meals");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movements.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movements.Data.Mappings
{
    public class MovementsMap : IEntityTypeConfiguration<Domain.Entities.Movement>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Movement> builder)
        {
            builder.ToTable("MANUAL_MOVIMENTS");

            builder.HasKey(key => new { key.EntryNumber, key.Month, key.Year });
                   

            builder.Property(p => p.Month)
            .HasMaxLength(2)
            .IsFixedLength();

            builder.Property(p => p.Year)
            .HasMaxLength(4)
            .IsFixedLength();

            builder.Property(p => p.EntryNumber)
            .HasMaxLength(18)
            .IsFixedLength();

            builder.Property(p => p.CodCosif)
              .HasMaxLength(11)
              .IsFixedLength();

            builder.Property(p => p.CodProduct)
              .HasMaxLength(4)
              .IsFixedLength();

            builder.Property(p => p.Description)
             .HasMaxLength(50)
             .IsRequired()
             .IsFixedLength();

            builder.Property(p => p.MovimentDate).IsRequired();

            builder.Property(p => p.UserCode)
            .HasMaxLength(15)
            .IsRequired()
            .IsFixedLength();

           builder.Property(p => p.Value)
           .HasMaxLength(18)
           .IsRequired()
           .IsFixedLength();

        }
    }
}

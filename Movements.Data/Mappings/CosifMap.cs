using Microsoft.EntityFrameworkCore;
using Movements.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movements.Data.Mappings
{
    public class CosifMap : IEntityTypeConfiguration<Cosif>
    {
        public void Configure(EntityTypeBuilder<Cosif> builder)
        {
            builder.ToTable("PRODUCT_COSIF");

            builder.HasKey(key => new { key.CodProduct, key.CodCosif });

            builder.Property(p => p.CodCosif)
               .HasMaxLength(11)
               .IsFixedLength();

            builder.Property(p => p.CodProduct)
              .HasMaxLength(4)
              .IsFixedLength();

            builder.Property(p => p.CodClassification)
             .HasMaxLength(6)
             .IsFixedLength();

            builder.Property(p => p.Status)
            .HasMaxLength(1)
            .IsFixedLength();

            builder.HasMany(x => x.Moviments).WithOne();
        }
    }
}

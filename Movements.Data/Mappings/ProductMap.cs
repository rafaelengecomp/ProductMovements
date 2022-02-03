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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(key => key.CodProduct);

            builder.ToTable("PRODUCT");            

            builder.Property(p => p.CodProduct)
                .HasMaxLength(4)
                .IsFixedLength();

            builder.Property(p => p.Description)
              .HasMaxLength(30)
              .IsFixedLength();

            builder.Property(p => p.Status)
             .HasMaxLength(1)
             .IsFixedLength();

            builder.HasMany(x => x.Cosif).WithOne();
        }
    }
}

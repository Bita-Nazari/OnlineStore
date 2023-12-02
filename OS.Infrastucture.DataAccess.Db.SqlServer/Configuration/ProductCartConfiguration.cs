using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.Db.SqlServer.Configuration
{
    public class ProductCartConfiguration : IEntityTypeConfiguration<ProductCart>
    {
        public void Configure(EntityTypeBuilder<ProductCart> builder)
        {
            builder.HasKey(pb => pb.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Cart).WithMany()
                .HasForeignKey(d => d.CartIds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCart_Cart");

            builder.HasOne(d => d.Products).WithMany()
                .HasForeignKey(d => d.ProductBoothIds)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_ProductCart_Product");
        }

    }
}

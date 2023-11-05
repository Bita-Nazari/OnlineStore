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
    public class ProductBoothConfiguration : IEntityTypeConfiguration<ProductBooth>
    {
        public void Configure(EntityTypeBuilder<ProductBooth> builder)
        {
            builder.ToTable("ProductBooth");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductBooths)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_ProductBooth_Product");

            builder.HasOne(d => d.booth)
                .WithMany(b => b.ProductBooths)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_ProductBooth_Booth");

        }
    }
}

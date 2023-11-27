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
    public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPicture");

            builder.HasOne(d => d.Picture).WithMany(p => p.ProductPictures)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPicture_Picture");

            builder.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductPicture_Product");
        }
    }
}

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
    public class BoothConfiguration : IEntityTypeConfiguration<Booth>
    {
        public void Configure(EntityTypeBuilder<Booth> builder)
        {
            builder.ToTable("Booth");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.Medal).WithMany(p => p.Booths)
                .HasForeignKey(d => d.MedalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Medal");

            builder.HasOne(d => d.Seller).WithMany(p => p.Booths)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Seller");
        }
    }
}

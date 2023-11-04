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
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.ToTable("Auction");

            builder.Property(e => e.EndTime).HasColumnType("datetime");
            builder.Property(e => e.StartTime).HasColumnType("datetime");

            builder.HasOne(d => d.Booth).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.BoothId)
                .HasConstraintName("FK_Auction_Booth");

            builder.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Auction_Product");

            builder.HasOne(d => d.Winner).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.WinnerId)
                .HasConstraintName("FK_Auction_Customer");
        }
    }
}

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
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bid");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Bid_Auction");

            builder.HasOne(d => d.Customer).WithMany(p => p.Bids)
       .HasForeignKey(d => d.CustomerId)
       .OnDelete(DeleteBehavior.NoAction)
       .HasConstraintName("FK_Bid_Customer");
        }
    }
}

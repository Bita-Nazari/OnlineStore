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
    public class MedalConfiguration : IEntityTypeConfiguration<Medal>
    {
        public void Configure(EntityTypeBuilder<Medal> builder)
        {
            builder.ToTable("Medal");

            builder.HasOne(d => d.MedalType).WithMany(p => p.Medals)
                .HasForeignKey(d => d.MedalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medal_MedalType");
        }
    }
}

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
    public class MedalTypeConfiguration : IEntityTypeConfiguration<MedalType>
    {
        public void Configure(EntityTypeBuilder<MedalType> builder)
        {
            builder.ToTable("MedalType");

            builder.Property(e => e.Type).HasMaxLength(50);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OS.Domain.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.Db.SqlServer.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
                  
       
            builder.ToTable("Admin");

            builder.Property(e => e.FirstName).HasMaxLength(50);
            builder.Property(e => e.LastName).HasMaxLength(50);
            builder.HasOne(x => x.User).WithOne(x => x.Admin);
            //builder.HasData(
            //   new Admin { FirstName = "Bita", LastName = "Nazari", Id = 1, UserId = 1, Wallet = 123456789 }
            //    );
        
        }
     
    }
}

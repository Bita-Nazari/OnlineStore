
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
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasData(
                new Province {Id = 1,Name = " یزد" },
                new Province { Id = 2, Name = " همدان" },
                new Province { Id = 3, Name = " هرمزگان" },
                new Province { Id = 4, Name = " مرکزی" },
                new Province { Id = 5, Name = " مازندران" },
                new Province { Id = 6, Name = " لرستان" },
                new Province { Id = 7, Name = " گیلان" },
                new Province { Id = 8, Name = " گلستان" },
                new Province { Id = 9, Name = " کهگیلویه و بویر احمد" },
                new Province { Id = 10, Name = " کرمانشاه" },
                new Province { Id = 11, Name = " کرمان" },
                new Province { Id = 12, Name = " کردستان" },
                new Province { Id = 13, Name = " قم" },
                new Province { Id = 14, Name = " قزوین" },
                new Province { Id = 15, Name = " فارس" },
                new Province { Id = 16, Name = " سیستان و بلوچستان" },
                new Province { Id = 17, Name = " سمنان" },
                new Province { Id = 18, Name = " زنجان" },
                new Province { Id = 19, Name = " خوزستان" },
                new Province { Id = 20, Name = " خراسان شمالی" },
                new Province { Id = 21, Name = " خراسان رضوی" },
                new Province { Id = 22, Name = " خراسان جنوبی" },
                new Province { Id = 23, Name = " چهارمحال بختیاری" },
                new Province { Id = 24, Name = " تهران" },
                new Province { Id = 25, Name = " بوشهر" },
                new Province { Id = 26, Name = " ایلام" },
                new Province { Id = 27, Name = " البرز" },
                new Province { Id = 28, Name = " اصفهان" },
                new Province { Id = 29, Name = " اردبیل" },
                new Province { Id = 30, Name = " آذربایجان غربی" },
                new Province { Id = 31, Name = " آذربایجان شرقی" }
                );
        }
    }
}

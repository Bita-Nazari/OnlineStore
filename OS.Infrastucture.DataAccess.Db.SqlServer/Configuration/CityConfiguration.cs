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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_City_Province");
            builder.HasData(
                new City { Id = 1 , Name = "یزد", ProvinceId =1 },
                new City { Id = 2 , Name = "میبد", ProvinceId =1 },
                new City { Id = 3, Name = "همدان", ProvinceId = 2 },
                new City { Id = 4 , Name = "ملایر", ProvinceId =2 },
                new City { Id = 5 , Name = "بندرعباس", ProvinceId =3 },
                new City { Id = 6, Name = "میناب", ProvinceId = 3},
                new City { Id = 7 , Name = "اراک", ProvinceId = 4},
                new City { Id = 8, Name = "خمین", ProvinceId =4 },
                new City { Id = 9, Name = "ساری", ProvinceId =5 },
                new City { Id = 10 , Name = "بابل", ProvinceId =5 },
                new City { Id = 11, Name = "بروجرد", ProvinceId =6 },
                new City { Id = 12, Name = "کوهدشت", ProvinceId =6 },
                new City { Id = 13, Name = "آستارا", ProvinceId =7 },
                new City { Id = 14, Name = "بندر انزلی", ProvinceId =7 },
                new City { Id = 15, Name = "گرگان", ProvinceId = 8},
                new City { Id = 16, Name = "گنبدکاووس", ProvinceId = 8},
                new City { Id = 17, Name = "یاسوج", ProvinceId = 9},
                new City { Id = 18, Name = "دهدشت", ProvinceId = 9},
                new City { Id = 19, Name = "جوانرود", ProvinceId =10 },
                new City { Id = 20, Name = "کرمانشاه", ProvinceId =10 },
                new City { Id = 21, Name = "کرمان", ProvinceId = 11},
                new City { Id = 22, Name = "رفسنجان", ProvinceId = 11},
                new City { Id = 23, Name = "سنندج", ProvinceId = 12},
                new City { Id = 24, Name = "سقز", ProvinceId = 12},
                new City { Id = 25, Name = "قم", ProvinceId = 13},
                new City { Id = 26, Name = "جعفریه", ProvinceId = 13},
                new City { Id = 27, Name = "قزوین", ProvinceId = 14},
                new City { Id = 28, Name = "تاکستان", ProvinceId = 14},
                new City { Id = 29, Name = "کازرون", ProvinceId = 15},
                new City { Id = 30, Name = "مرودشت", ProvinceId = 15},
                new City { Id = 31, Name = "زاهدان", ProvinceId = 16},
                new City { Id = 32, Name = "چابهار", ProvinceId = 16},
                new City { Id = 33, Name = "شاهرود", ProvinceId = 17},
                new City { Id = 34, Name = "دامغان", ProvinceId = 17},
                new City { Id = 35, Name = "زنجان", ProvinceId = 18},
                new City { Id = 36, Name = "ابهر", ProvinceId = 18},
                new City { Id = 37, Name = "دزفول", ProvinceId = 19},
                new City { Id = 38, Name = "اهواز", ProvinceId = 19},
                new City { Id = 39, Name = "بجنورد", ProvinceId = 20},
                new City { Id = 40, Name = "شیروان", ProvinceId = 20},
                new City { Id = 41, Name = "نیشابور", ProvinceId = 21},
                new City { Id = 42, Name = "سبزوار", ProvinceId = 21},
                new City { Id = 43, Name = "بیرجند", ProvinceId = 22},
                new City { Id = 44, Name = "فردوس", ProvinceId = 22},
                new City { Id = 45, Name = "شهرکرد", ProvinceId = 23},
                new City { Id = 46, Name = "بروجن", ProvinceId = 23},
                new City { Id = 47, Name = "تهران", ProvinceId = 24},
                new City { Id = 48, Name = "ری", ProvinceId = 24},
                new City { Id = 49, Name = "پاکدشت", ProvinceId = 24},
                new City { Id = 50, Name = "ورامین", ProvinceId = 24},
                new City { Id = 51, Name = "بندربوشهر", ProvinceId = 25},
                new City { Id = 52, Name = "برازجان", ProvinceId = 25},
                new City { Id = 53, Name = "ایلام", ProvinceId = 26},
                new City { Id = 54, Name = "ایوان", ProvinceId = 26},
                new City { Id = 55, Name = "اشتهارد", ProvinceId = 27},
                new City { Id = 56, Name = "طالقان", ProvinceId = 27},
                new City { Id = 57, Name = "کاشان", ProvinceId = 28},
                new City { Id = 58, Name = "اصفهان", ProvinceId = 28},
                new City { Id = 59, Name = "اردبیل", ProvinceId = 29},
                new City { Id = 60, Name = "پارس آباد", ProvinceId = 29},
                new City { Id = 61, Name = "مشکین شهر", ProvinceId = 29},
                new City { Id = 62, Name = "ارومیه", ProvinceId = 30},
                new City { Id = 63, Name = "خوی", ProvinceId = 30},
                new City { Id = 64, Name = "بوکان", ProvinceId =30 },
                new City { Id = 65, Name = "میانه", ProvinceId = 31},
                new City { Id = 66, Name = "سراب", ProvinceId =31 },
                new City { Id = 67, Name = "تبریز", ProvinceId = 31},
                new City { Id = 68, Name = "اسلام شهر", ProvinceId = 24},
                new City { Id = 69, Name = "شهریار", ProvinceId = 24},
                new City { Id = 70, Name = "خمینی شهر", ProvinceId =28 },
                new City { Id = 71, Name = "نجف اباد", ProvinceId =28 },
                new City { Id =72 , Name = "شاهین شهر", ProvinceId = 28}


                );
        }
    }
}

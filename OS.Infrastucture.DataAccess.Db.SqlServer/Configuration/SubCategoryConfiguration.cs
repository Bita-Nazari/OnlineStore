using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OS.Domain.Core.Entities;

namespace OS.Infrastucture.Db.SqlServer.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategory");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubCategory_Category");

            builder.HasData(
            new SubCategory { Id = 1, Name = "موبایل", CategoryId = 1 },
            new SubCategory { Id = 2, Name = "لپ تاپ", CategoryId = 1 },
            new SubCategory { Id = 3, Name = "دوربین", CategoryId = 1 },
            new SubCategory { Id = 4, Name = "کنسول بازی", CategoryId = 1 },
            new SubCategory { Id = 5, Name = "کامپیوتر و تجهیزات", CategoryId = 1 },
            new SubCategory { Id = 6, Name = "ساعت دیجیتال", CategoryId = 1 },
            new SubCategory { Id = 7, Name = "شستشو و نظافت", CategoryId = 2 },
            new SubCategory { Id = 8, Name = "آشپزخانه", CategoryId = 2 },
            new SubCategory { Id = 9, Name = "سرو پذیرایی", CategoryId = 2 },
            new SubCategory { Id = 10, Name = "لوازم خانگی برقی", CategoryId = 2 },
            new SubCategory { Id = 11, Name = "فرش و گلیم", CategoryId = 2 },
            new SubCategory { Id = 12, Name = "دکوراسیون", CategoryId = 2 },
            new SubCategory { Id = 13, Name = "مردانه", CategoryId = 3 },
            new SubCategory { Id = 14, Name = "زنانه", CategoryId = 3 },
            new SubCategory { Id = 15, Name = "بچگانه", CategoryId = 3 },
            new SubCategory { Id = 16, Name = "کفش ", CategoryId = 3 },
            new SubCategory { Id = 17, Name = "کتاب", CategoryId = 4 },
            new SubCategory { Id = 18, Name = "مجلات", CategoryId = 4 },
            new SubCategory { Id = 19, Name = "لوازم تحریر", CategoryId = 4 },
            new SubCategory { Id = 20, Name = "تغذیه و رشد کودک", CategoryId = 5 },
            new SubCategory { Id = 21, Name = "بهداشت و حمام", CategoryId = 5 },
            new SubCategory { Id = 22, Name = "لوازم آرایشی", CategoryId = 6 },
            new SubCategory { Id = 23, Name = "لوازم بهداشتی", CategoryId = 6 },
            new SubCategory { Id = 24, Name = "لوازم شخصی برقی", CategoryId = 6 },
            new SubCategory { Id = 25, Name = "عطر و ادکلن", CategoryId = 6 },
            new SubCategory { Id = 26, Name = "پوشاک ورزشی", CategoryId = 7 },
            new SubCategory { Id = 27, Name = "کفش ورزشی", CategoryId = 7 },
            new SubCategory { Id = 28, Name = "لوازم ورزشی", CategoryId = 7 },
            new SubCategory { Id = 29, Name = "ابزار غیربرقی", CategoryId = 8 },
            new SubCategory { Id = 30, Name = "باغبانی و کشاورزی", CategoryId = 8 },
            new SubCategory { Id = 31, Name = "ابزار برقی و شارژی", CategoryId = 8 },
            new SubCategory { Id = 32, Name = "گردنبند", CategoryId = 9 },
            new SubCategory { Id = 33, Name = "انگشتر", CategoryId = 9  },
            new SubCategory { Id = 34, Name = "عینک آفتابی", CategoryId = 9 },
            new SubCategory { Id = 35, Name = "دستبند", CategoryId = 9 },
            new SubCategory { Id = 35, Name = "کلاه", CategoryId =9  }


                );
        }
    }
}

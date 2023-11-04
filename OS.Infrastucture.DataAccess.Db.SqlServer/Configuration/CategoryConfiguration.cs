using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OS.Domain.Core.Entities;

namespace OS.Infrastucture.Db.SqlServer.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.Property(e => e.Name).HasMaxLength(50);
            builder.HasData(
             new Category {Id = 1 ,Name = "کالای دیجیتال" },
             new Category { Id = 2, Name = "خانه وآشپزخانه" },
             new Category { Id = 3, Name = "مد و پوشاک" },
             new Category { Id = 4, Name = "کتاب و لوازم تحریر" },
             new Category { Id = 5, Name = "اسباب بازی،کودک و نوزاد" },
             new Category { Id = 6, Name = "زیبایی و سلامت" },
             new Category { Id = 7, Name = "ورزش و سفر" },
             new Category { Id = 8, Name = "ابزارآلات و تجهیزات" },
             new Category { Id = 9, Name = "اکسسوری" }
                );
        }
    }
}

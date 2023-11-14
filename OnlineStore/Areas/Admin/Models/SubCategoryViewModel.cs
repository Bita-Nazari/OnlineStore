using OS.Domain.Core.Entities;

namespace OnlineStore.Areas.Admin.Models
{
    public class SubCategoryViewModel
    {
        public int SubCategoryId { get; set; }
        public string? SubcategoryName { get; set; }
        public List<SubCategory> subCategories { get; set; }
    }
}

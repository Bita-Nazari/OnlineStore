using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}

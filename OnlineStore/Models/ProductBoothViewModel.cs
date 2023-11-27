using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class ProductBoothViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubcategoryId { get; set; }
        public string? SubcategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int BoothId { get; set; }
        public string? BoothName { get; set; }
        public long NewPrice { get; set; }
        public int Count { get; set; }

        public virtual Booth booth { get; set; } = null!;
        public List<Picture>? Pictures { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}

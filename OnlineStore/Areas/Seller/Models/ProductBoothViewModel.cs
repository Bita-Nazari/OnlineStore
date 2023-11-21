using OS.Domain.Core.Entities;

namespace OnlineStore.Areas.Seller.Models
{
    public class ProductBoothViewModel
    {
        public int Id { get; set; }
        public int? SellerId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int BoothId { get; set; }
        public long NewPrice { get; set; }
        public int Count { get; set; }

        public virtual Booth? booth { get; set; } = null!;

        public virtual Product? Product { get; set; } = null!;
        public List<Product>? Products { get; set; }
    }
}

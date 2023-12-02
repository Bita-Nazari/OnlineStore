using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }
        public List<Picture>? Pictures { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ProductName { get; set; }
        public long? ProductPrice { get; set; }
        public long? TotalPrice { get; set; }
        public virtual Booth Booth { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public List<ProductBooth> Products { get; set; }

    }
}

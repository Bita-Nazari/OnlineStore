using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public long Price { get; set; }

        public string Description { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime CreatedAt { get; set; }

        public int BoothId { get; set; }

        public int SubCategoryId { get; set; }

        public bool IsAvailable { get; set; }
        public long StartPrice { get; set; }
        public string? ProductName { get; set; }

        public int Count { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual Booth Booth { get; set; } = null!;

        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();
        public List<Picture> pictures { get; set; }

        public virtual SubCategory SubCategory { get; set; } = null!;
    }
}

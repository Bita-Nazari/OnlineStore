using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public long? TotalPrice { get; set; }

        public int? CustomerId { get; set; }

        public int? StatusId { get; set; }
        public string? StatusName { get; set; }

        public int? CartId { get; set; }

        public int? Commession { get; set; }

        public virtual Cart Cart { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual Customer Customer { get; set; } = null!;

        public virtual List<ProductOrder>? ProductOrders { get; set; } = new List<ProductOrder>();
        public List<Product>? Products { get; set; }
        public List<ProductCart>? ProductCarts { get; set; }
        public List<ProductBooth>? ProductBooth { get; set; }
        public List<Booth>? Booths { get; set; }
        public List<Picture> ?Pictures { get; set; }

        public virtual Status? Status { get; set; }
    }
}

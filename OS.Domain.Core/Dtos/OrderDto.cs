using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public long? TotalPrice { get; set; }

        public int? CustomerId { get; set; }

        public int? StatusId { get; set; }
        public string? StatusName { get; set; }

        public int? CartId { get; set; }
        public int? BoothId { get; set; }

        public int? Commession { get; set; }
        public string? FirstName { get; set; }
        public string CustomerUsername { get; set; }
        public int? AuctionId { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; } = null!;

        public int? CityId { get; set; }
        public string? CityName { get; set; }

        public int? PictureId { get; set; }

        public bool? IsDeleted { get; set; }

        public long? Wallet { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserId { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public Auction auction { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual Customer Customer { get; set; } = null!;

        public virtual List<ProductOrder>? ProductOrders { get; set; } = new List<ProductOrder>();
        public List<Product> Products { get; set; }
        public List<ProductCart> ProductCarts { get; set; }
        public List<ProductBooth>? ProductBooths { get; set; }
        public List<Booth>? Booths { get; set; }
        public List<Picture> Pictures { get; set; }

        public virtual Status Status { get; set; } = null!;
    }
}

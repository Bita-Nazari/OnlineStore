using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class ProductDto
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

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual Booth Booth { get; set; } = null!;

        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();

        public virtual SubCategory SubCategory { get; set; } = null!;
    }
}

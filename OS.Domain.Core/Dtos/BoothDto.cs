using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class BoothDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public int SellerId { get; set; }

        public int TotalCount { get; set; }

        public int MedalId { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual Medal Medal { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual Seller Seller { get; set; } = null!;
    }
}

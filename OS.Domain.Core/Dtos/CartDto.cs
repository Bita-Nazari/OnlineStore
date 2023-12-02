using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public long? ProductPrice { get; set; }
        public long? TotalPrice { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Booth Booth { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public List<ProductBooth> Products { get; set; }
        public List<Picture> Pictures { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

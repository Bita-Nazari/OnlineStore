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

        public long TotalPrice { get; set; }

        public int CustomerId { get; set; }

        public int  StatusId { get; set; }

        public int CartId { get; set; }

        public int Commession { get; set; }

        public virtual Cart Cart { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual Customer Customer { get; set; } = null!;

        public virtual List<ProductOrder>? ProductOrders { get; set; } = new List<ProductOrder>();
        public List<ProductCart> ProductCarts { get; set; }
        public List<ProductBooth>? Products { get; set; }
        public List<Booth>? Booths { get; set; }

        public virtual Status Status { get; set; } = null!;
    }
}

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

        public int CustomerId { get; set; }

        public int BoothId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Booth Booth { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

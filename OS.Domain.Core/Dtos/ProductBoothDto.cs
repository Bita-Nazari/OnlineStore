using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class ProductBoothDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BoothId { get; set; }
        public long NewPrice { get; set; }
        public int Count { get; set; }

        public virtual Booth booth { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}

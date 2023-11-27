using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class ProductOrderDto
    {
        public int Id { get; set; }

        public int ProductBoothId { get; set; }

        public int OrderId { get; set; }


        public virtual Order Order { get; set; } = null!;

        public virtual ProductBooth Product { get; set; } = null!;
    }
}

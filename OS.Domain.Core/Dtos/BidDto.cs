using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class BidDto
    {
        public int Id { get; set; }

        public long SuggestedPrice { get; set; }

        public int CustomerId { get; set; }

        public bool IsCreated { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int AuctionId { get; set; }

        public virtual Auction Auction { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}

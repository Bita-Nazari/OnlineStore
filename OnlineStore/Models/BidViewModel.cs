﻿using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class BidViewModel
    {
        public int Id { get; set; }

        public long SuggestedPrice { get; set; }

        public long LastPrice { get; set; }
        public int CustomerId { get; set; }

        public bool IsCreated { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int AuctionId { get; set; }

        public virtual Auction Auction { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}

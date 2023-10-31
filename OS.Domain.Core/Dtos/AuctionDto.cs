﻿using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class AuctionDto
    {
        public int Id { get; set; }

        public long StartPrice { get; set; }

        public int BoothId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int? WinnerId { get; set; }

        public int ProductId { get; set; }

        public int BidCount { get; set; }

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual Booth Booth { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;

        public virtual Customer? Winner { get; set; }
    }
}
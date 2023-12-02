using OS.Domain.Core.Entities;
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
        public int CustomerId { get; set; }
        public string? BoothName { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int? WinnerId { get; set; }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? SubcategoryName { get; set; }
        public string? Description { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsStarted { get; set; }
        public int BidCount { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime persianstart { get; set; }

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
        public List<Picture> Pictures { get; set; }

        public virtual Booth Booth { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;

        public virtual Customer? Winner { get; set; }
    }
}

using OS.Domain.Core.Entities;

namespace OnlineStore.Areas.Seller.Models
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        public long StartPrice { get; set; }

        public int BoothId { get; set; }
        public int SellerId { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;

        public DateTime EndTime { get; set; } = DateTime.Now;

        public int? WinnerId { get; set; }

        public int ProductId { get; set; }

        public int BidCount { get; set; }

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual Booth Booth { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;

        public virtual Customer? Winner { get; set; }
    }
}

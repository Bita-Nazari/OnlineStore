using OS.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Areas.Seller.Models
{
    public class AuctionViewModel
    {
        public int? Id { get; set; }

        public long StartPrice { get; set; }

        public int BoothId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? ProductName { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;
        //public DateTime persianstart { get; set; }

        public DateTime EndTime { get; set; } = DateTime.Now;

        public int? WinnerId { get; set; }
        public string? Description { get; set; }
        public string? SubCategoryName { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsStarted { get; set; }


        [Display(Name ="محصولات")]
        public int ProductId { get; set; }

        public int? BidCount { get; set; }

        //public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual Customer? Winner { get; set; }
        public List<Product>? Products { get; set; }
        public List<Picture>? pictures { get; set; }
    }
}

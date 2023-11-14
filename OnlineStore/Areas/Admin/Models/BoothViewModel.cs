using OS.Domain.Core.Entities;
using System.ComponentModel;

namespace OnlineStore.Areas.Admin.Models
{
    public class BoothViewModel
    {

        public int Id { get; set; }
        [DisplayName("نام غرفه")]
        public string? Name { get; set; } = null!;
        [DisplayName("توضیحات")]
        public string? Description { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
        [DisplayName("نام فروشنده")]
        public string? SellerName { get; set; }
        public int SellerId { get; set; }
        [DisplayName("فروش کل")]
        public int? TotalCount { get; set; }

        public int MedalId { get; set; }
        [DisplayName("مدال")]
        public string? Medalname { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual Medal Medal { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Medal> Medals { get; set; } = new List<Medal>();

        public virtual Seller Seller { get; set; } = null!;
    }
}

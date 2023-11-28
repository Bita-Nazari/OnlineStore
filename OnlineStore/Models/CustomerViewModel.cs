using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string?  UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; } = null!;

        public int? CityId { get; set; }
        public string? CityName { get; set; }

        public int? PictureId { get; set; }

        public bool? IsDeleted { get; set; }

        public long? Wallet { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserId { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual City City { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual Picture Picture { get; set; } = null!;
    }
}

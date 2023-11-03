using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long PhoneNumber { get; set; }

    public string Address { get; set; } = null!;

    public int CityId { get; set; }

    public int PictureId { get; set; }

    public bool IsDeleted { get; set; }

    public long Wallet { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Picture Picture { get; set; } = null!;
    public User User { get; set; }
}

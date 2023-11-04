using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Booth
{
    #region Properties

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public int SellerId { get; set; }

    public int TotalCount { get; set; }

    public int MedalId { get; set; }

    #endregion Properties

    #region Navigation properties
    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Medal Medal { get; set; } = null!;

    public virtual ICollection<ProductBooth> ProductBooths { get; set; } = new List<ProductBooth>();


    public virtual Seller Seller { get; set; } = null!;


    #endregion Navigation properties


}

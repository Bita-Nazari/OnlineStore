using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Product
{
    #region Properties
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public long BasePrice { get; set; }

    public string Description { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public bool IsConfirmed { get; set; }

    public DateTime CreatedAt { get; set; }

    public int SubCategoryId { get; set; }

    public bool IsAvailable { get; set; }

    #endregion Properties

    #region Navigation properties

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();
    public virtual ICollection<ProductBooth> ProductBooths { get; set; } = new List<ProductBooth>();

    public virtual SubCategory SubCategory { get; set; } = null!;

    #endregion Navigation properties



}

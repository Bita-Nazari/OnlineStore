using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Bid
{
    #region Properties
    public int Id { get; set; }

    public long SuggestedPrice { get; set; }

    public int CustomerId { get; set; }

    public bool IsCreated { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; }

    public int AuctionId { get; set; }


    #endregion Properties

    #region Navigation properties

    public virtual Auction Auction { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    #endregion Navigation properties


}

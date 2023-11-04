using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Auction
{
    #region Properties
    public int Id { get; set; }

    public long StartPrice { get; set; }

    public int BoothId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? WinnerId { get; set; }

    public int ProductId { get; set; }

    public int BidCount { get; set; }

    #endregion Properties

    #region Navigation properties

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual Booth Booth { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Customer? Winner { get; set; }

    #endregion Navigation properties



}

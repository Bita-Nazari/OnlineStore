using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Cart
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

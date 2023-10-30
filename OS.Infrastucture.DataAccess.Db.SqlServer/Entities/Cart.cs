using System;
using System.Collections.Generic;

namespace OS.Infrastucture.Db.SqlServer.Entities;

public partial class Cart
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int BoothId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Status
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

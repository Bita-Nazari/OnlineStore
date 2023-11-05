using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Cart
{
    #region Properties
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedAt { get; set; }

    #endregion Properties

    #region Navigation properties


    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    #endregion Navigation properties


}

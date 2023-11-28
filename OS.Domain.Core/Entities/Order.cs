using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Order
{
    #region Properties
    public int Id { get; set; }

    public long TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public int? StatusId { get; set; }

    public int CartId { get; set; }

    public int Commession { get; set; }


    #endregion Properties

    #region Navigation properties
    public virtual Cart Cart { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    public virtual Status Status { get; set; } = null!;

    #endregion Navigation properties


}

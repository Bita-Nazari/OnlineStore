using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class ProductCart
{
    public int Id { get; set; }

    public int ProductBoothId { get; set; }

    public int CartId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual ProductBooth ProductBooth { get; set; } = null!;
}

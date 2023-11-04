using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class ProductCart
{
    #region Properties
    public int Id { get; set; }

    public int ProductBoothId { get; set; }

    public int CartId { get; set; }

    #endregion Properties

    #region Navigation properties

    public virtual Cart Cart { get; set; } = null!;

    public virtual ProductBooth ProductBooth { get; set; } = null!;

    #endregion Navigation properties



}

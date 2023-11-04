﻿using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class ProductOrder
{
    #region Properties

    public int Id { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }
    #endregion Properties

    #region Navigation properties

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    #endregion Navigation properties



}

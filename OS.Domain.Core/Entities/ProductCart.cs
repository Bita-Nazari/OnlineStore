using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class ProductCart
{
    #region Properties
    public int Id { get; set; }

    public int? ProductBoothIds { get; set; }

    public int? CartIds { get; set; }

    #endregion Properties

    #region Navigation properties

    public virtual Cart? Cart { get; set; } 

    public virtual ProductBooth? Products { get; set; } 

    #endregion Navigation properties



}

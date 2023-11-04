using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class ProductPicture
{
    #region Properties

    public int Id { get; set; }

    public int ProductId { get; set; }

    public int PictureId { get; set; }
    #endregion Properties

    #region Navigation properties

    public virtual Picture Picture { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    #endregion Navigation properties



}

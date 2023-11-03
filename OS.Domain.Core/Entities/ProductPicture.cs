using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class ProductPicture
{
    #region Properties


    #endregion Properties
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int PictureId { get; set; }

    public virtual Picture Picture { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

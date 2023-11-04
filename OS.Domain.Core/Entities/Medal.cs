using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Medal
{
    #region Properties
    public int Id { get; set; }

    public int MedalTypeId { get; set; }

    public int Discount { get; set; }

    #endregion Properties

    #region Navigation properties


    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual MedalType MedalType { get; set; } = null!;

    #endregion Navigation properties


}

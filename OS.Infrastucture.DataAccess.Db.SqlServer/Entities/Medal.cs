using System;
using System.Collections.Generic;

namespace OS.Infrastucture.Db.SqlServer.Entities;

public partial class Medal
{
    public int Id { get; set; }

    public int MedalTypeId { get; set; }

    public int Discount { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual MedalType MedalType { get; set; } = null!;
}

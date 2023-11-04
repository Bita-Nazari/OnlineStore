using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class MedalType
{

    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Medal> Medals { get; set; } = new List<Medal>();
}

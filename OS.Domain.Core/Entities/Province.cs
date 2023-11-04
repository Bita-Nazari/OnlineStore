using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Province
{
    #region Properties
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    #endregion Properties

    #region Navigation properties

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    #endregion Navigation properties



}

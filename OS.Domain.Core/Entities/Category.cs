using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Category
{
    #region Properties
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }


    #endregion Properties

    #region Navigation properties

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    #endregion Navigation properties


}

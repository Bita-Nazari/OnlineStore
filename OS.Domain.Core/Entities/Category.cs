using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}

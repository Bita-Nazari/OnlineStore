using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class SubCategory
{
    #region Properties
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public bool IsDeleted { get; set; }

    #endregion Properties

    #region Navigation properties
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();


    #endregion Navigation properties



}

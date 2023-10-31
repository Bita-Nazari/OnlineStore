using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}

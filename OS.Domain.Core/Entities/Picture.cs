using System;
using System.Collections.Generic;

namespace OS.Infrastucture.Db.SqlServer.Entities;

public partial class Picture
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public bool IsConfirmed { get; set; }

    public bool IsProfilePicture { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}

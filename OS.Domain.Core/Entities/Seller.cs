using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Seller
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long NationalCode { get; set; }

    public long PhoneNumber { get; set; }

    public int CityId { get; set; }

    public int PictureId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UserId { get; set; }

    public long ShabaNumber { get; set; }

    public long Wallet { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual City City { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;

    public User User { get; set; }
}

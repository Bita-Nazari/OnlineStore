using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Seller
{
    #region Properties

    public int Id { get; set; }

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public long? NationalCode { get; set; }


    public int? CityId { get; set; }

    public int? PictureId { get; set; }

    public bool? IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; }

    public int? UserId { get; set; }

    public long? ShabaNumber { get; set; }

    public long? Wallet { get; set; }
    #endregion Properties

    #region Navigation properties
    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual City? City { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;

    public User User { get; set; }


    #endregion Navigation properties



}

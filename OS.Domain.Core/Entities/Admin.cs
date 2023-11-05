using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;

public partial class Admin
{
    #region Properties
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long Wallet { get; set; }


    public int? UserId { get; set; }

    #endregion Properties

    #region Navigation properties

    public User User { get; set; }

    #endregion Navigation properties

}

using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;

public partial class Admin
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long Wallet { get; set; }

    public long PhoneNumber { get; set; }

    public int? UserId { get; set; }
}

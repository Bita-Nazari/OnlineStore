using System;
using System.Collections.Generic;

namespace OS.Domain.Core.Entities;


public partial class Comment
{
    #region Properties
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int CustomerId { get; set; }

    public int OrderId { get; set; }

    public int BoothId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsConfirmed { get; set; }

    public bool IsDeleted { get; set; } = false;

    #endregion Properties



    #region Navigation properties
    public virtual Booth Booth { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;


    #endregion Navigation properties



}

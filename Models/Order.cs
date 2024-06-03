using System;
using System.Collections.Generic;

namespace QanShopWebApi.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public int Total { get; set; }

    public Guid CartId { get; set; }

    public Guid UserId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace QanShopWebApi.Models;

public partial class Cart
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product Product { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace QanShopWebApi.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public int Price { get; set; }

    public Guid CategoryId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;
}

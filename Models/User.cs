using System;
using System.Collections.Generic;

namespace QanShopWebApi.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

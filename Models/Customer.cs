using System;
using System.Collections.Generic;

namespace Barashikhina_Sofia.Models;

public partial class Customer
{
    public int CustomersId { get; set; }

    public string CustomersName { get; set; } = null!;

    public string? CustomersInn { get; set; }

    public string CustomersAddres { get; set; } = null!;

    public string CustomersPhone { get; set; } = null!;

    public bool? CustomersSalesman { get; set; }

    public bool? CustomersBuyer { get; set; }

    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
}

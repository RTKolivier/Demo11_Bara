using System;
using System.Collections.Generic;

namespace Barashikhina_Sofia.Models;

public partial class Production
{
    public int ProductionId { get; set; }

    public string ProductionName { get; set; } = null!;

    public int ProductionCost { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}

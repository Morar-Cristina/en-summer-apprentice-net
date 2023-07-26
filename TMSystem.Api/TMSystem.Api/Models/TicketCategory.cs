using System;
using System.Collections.Generic;

namespace TMSystem.Api.Models;

public partial class TicketCategory
{
    public int TicketCategoryId { get; set; }

    public int? EventId { get; set; }

    public string? TicketDescription { get; set; }

    public decimal? TicketPrice { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

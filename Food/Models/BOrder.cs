using System;
using System.Collections.Generic;

namespace Food.Models;

public partial class BOrder
{
    public string OrderId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? DiscountId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public decimal AmountBeforeDiscount { get; set; }

    public decimal TotalAmount { get; set; }

    public string? ShippingAddress { get; set; }
}

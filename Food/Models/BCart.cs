using System;
using System.Collections.Generic;

namespace Food.Models;

public partial class BCart
{
    public string CartId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? ProductId { get; set; }

    public int Quantity { get; set; }
}

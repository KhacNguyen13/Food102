using System;
using System.Collections.Generic;

namespace Food.Models;

public partial class BMenu
{
    public string MenuId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? Parent { get; set; }

    public string? Position { get; set; }

    public bool? IsActive { get; set; }
}

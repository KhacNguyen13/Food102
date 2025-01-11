using System;
using System.Collections.Generic;

namespace Food.Models;

public partial class BBlog
{
    public string BlogId { get; set; } = null!;

    public string? CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public string AuthorId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public string? Image { get; set; }
}

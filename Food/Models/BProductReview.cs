using System;
using System.Collections.Generic;

namespace Food.Models;

public partial class BProductReview
{
    public int ProductReviewId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Detail { get; set; }

    public int? Star { get; set; }

    public string? ProductId { get; set; }

    public bool? IsActive { get; set; }
}

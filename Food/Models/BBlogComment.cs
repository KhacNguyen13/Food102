using System;
using System.Collections.Generic;

namespace Food.Models;

public partial class BBlogComment
{
    public int CommentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Detail { get; set; }

    public string BlogId { get; set; } = null!;

    public bool? IsActive { get; set; }
}

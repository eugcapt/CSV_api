using System;
using System.Collections.Generic;

namespace CSV_api.Models;

public partial class Comment
{
    public int? CommentId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? TaskId { get; set; }

    public virtual Task? Task { get; set; }
}

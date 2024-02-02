using System;
using System.Collections.Generic;

namespace CSV_api.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Int16 Status { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? ProjectId { get; set; }

    public virtual Project? Project { get; set; }
}

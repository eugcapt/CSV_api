using System;
using System.Collections.Generic;

namespace CSV_api.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Login { get; set; }

    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public string Email { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? ProjectId { get; set; }

    public virtual Project? Project { get; set; }
}

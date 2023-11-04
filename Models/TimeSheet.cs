using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class TimeSheet
{
    public int Id { get; set; }

    public int Hours { get; set; }

    public int PersonId { get; set; }

    public int ProjectId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}

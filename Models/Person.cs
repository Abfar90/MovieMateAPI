using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();
}

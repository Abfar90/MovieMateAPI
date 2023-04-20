using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class MovieDetail
{
    public int MovieId { get; set; }

    public string Link { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateTime Release { get; set; }
}

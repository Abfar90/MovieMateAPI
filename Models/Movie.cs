using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public decimal? Rating { get; set; }

    public int UserId { get; set; }

    public virtual MovieDetail MovieNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

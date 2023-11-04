using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class Movie
{
    public int Id { get; set; }

    public int MovieDetailsId { get; set; }

    public decimal? Rating { get; set; }

    public int UserId { get; set; }

    public virtual MovieDetail MovieDetails { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

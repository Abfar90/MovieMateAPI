using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class MovieGenre
{
    public int MovieId { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual MovieDetail Movie { get; set; } = null!;
}

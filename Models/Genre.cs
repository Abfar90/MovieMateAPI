using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<UserGenre> UserGenres { get; set; } = new List<UserGenre>();
}

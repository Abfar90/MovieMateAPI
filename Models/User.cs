using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public virtual ICollection<UserGenre> UserGenres { get; set; } = new List<UserGenre>();
}

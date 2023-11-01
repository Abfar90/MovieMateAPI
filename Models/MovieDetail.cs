using System;
using System.Collections.Generic;

namespace MovieMateAPI.Models;

public partial class MovieDetail
{
    public int Id { get; set; }

    public string Link { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateTime Release { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

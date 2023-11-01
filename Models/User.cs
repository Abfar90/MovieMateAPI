using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieMateAPI.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

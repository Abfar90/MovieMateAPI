using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieMateAPI.Models;

public partial class UserGenre
{
    [Key]
    public int id { get; set; }
    public int GenreId { get; set; }

    public int UserId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

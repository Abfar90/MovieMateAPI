using System;
using System.Collections.Generic;

namespace MovieMateAPI.DTOs
{
    public class MovieDetailDTO
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string Title { get; set; }

        public DateTime Release { get; set; }

        public ICollection<MovieDTO> Movies { get; set; }
    }
}

namespace MovieMateAPI.DTOs
{
    public class UserDTO
    {
        //public int UserId { get; set; }
        public string? Name { get; set; }
        //public string? Email { get; set; }

        public List<MovieDTO> Movies { get; set; } // Represents related movies
        public List<GenreDTO> UserGenres { get; set; } // Represents related user genres
    }
}

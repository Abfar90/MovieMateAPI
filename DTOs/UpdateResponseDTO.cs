namespace MovieMateAPI.DTOs
{
    public class UpdateResponseDTO
    {
        public string title { get; set; }
        public decimal? oldRating { get; set; }
        public decimal? newRating { get; set; }

    }
}

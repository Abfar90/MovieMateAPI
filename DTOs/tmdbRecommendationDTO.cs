using MovieMateAPI.Classes;
using Newtonsoft.Json;

namespace MovieMateAPI.DTOs
{
    public class tmdbRecommendationDTO
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }

        [JsonProperty("release_date")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime ReleaseDate { get; set; }
    }
}

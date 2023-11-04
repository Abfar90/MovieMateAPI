using MovieMateAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using Newtonsoft.Json;
using MovieMateAPI.DTOs;
using AutoMapper;

namespace MovieMateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieMateDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly string _tmdbApiKey = "48c0cf6aedcef3fd366e65f0d509de1b";

        public MovieController(MovieMateDbContext context, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        // GET: api/Users

        [HttpGet]
        [Route("AllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        // GET: api/Users/1
        [HttpGet]
        [Route("User/{id}")] //visa namn på personen, vilka genrer de gillar, vilka filmer de sparat
        public async Task<ActionResult<IEnumerable<Movie>>> GetUserByID(int id)
        {
            return Ok(await _context.Movies.Where(x => x.UserId == id).Include(y => y.MovieDetails).ThenInclude(p => p.Movies).
                Select(m => new
                {
                    Title = m.MovieDetails.Title,
                    Release = m.MovieDetails.Release,
                    Rating = m.Rating,
                }).ToListAsync());

        }

        // GET: api/Users/Movies
        [HttpGet]
        [Route("Movies/{id}")]
        public async Task<ActionResult<List<Movie>>> GetUserMovies(int id)
        {
            var UserMovies = await _context.Movies.Where(m => m.UserId == id)
                                           .Include(details => details.MovieDetails)
                                           .ToListAsync();
            return Ok(UserMovies);
        }

        //GET: api/Genres
        [HttpGet]
        [Route("Genre/{id}")]
        public async Task<ActionResult<List<Genre>>> GetUserGenres(int id)
        {
            return Ok(await _context.UserGenres.Where(x => x.UserId == id).Include(g => g.Genre).
                Select(g => new
                {
                    Title = g.Genre.Title,
                    Description = g.Genre.Description,
                }).ToListAsync());
        }

        //POST: api/Genres
        [HttpPost]
        [Route("Genre/post")]
        public async Task<ActionResult<List<UserGenre>>> postUserGenres(createUserGenredDTO newUserGenre)
        {
            var context = _context.UserGenres;

            var newEntry = _mapper.Map<UserGenre>(newUserGenre);

            context.Add(newEntry);

            await _context.SaveChangesAsync();

            return Ok(await _context.UserGenres.Where(x => x.UserId == newEntry.UserId).Include(g => g.Genre).
                Select(g => new
                {
                    Title = g.Genre.Title,
                    Description = g.Genre.Description,
                }).ToListAsync());
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult<List<Movie>>> RateMovie(int id, UpdateRatingDTO updateDTO)
        {
            var dbmovie = await _context.Movies.Where(x => x.MovieDetailsId == id).Include(m => m.MovieDetails).FirstAsync();

            if (dbmovie == null)
            {
                return BadRequest("Movie not found");
            }

            dbmovie.Rating = updateDTO.rating;

            await _context.SaveChangesAsync();

            var ratedMovies = await _context.Movies.Where(x => x.UserId == updateDTO.userId && x.Rating != null).Include(m => m.MovieDetails).ToListAsync();

            var responseDTOs = ratedMovies.Select(m => new UpdateResponseDTO
            {
                MovieDetailsId = m.MovieDetailsId,
                title = m.MovieDetails.Title,
                rating = m.Rating

            }).ToList();

            return Ok(responseDTOs);
        }

        [HttpGet("Recommendations/{genreId}")]
        public async Task<ActionResult> GetRecommendationbyGenre(int genreId)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new System.Uri("https://api.themoviedb.org/3/");

                var response = await httpClient.GetAsync($"discover/movie?api_key={_tmdbApiKey}&with_genres={genreId}&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_watch_monetization_types=flatrate&with_original_language=en&watch_region=US");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var movieRecommendationResponse = JsonConvert.DeserializeObject<tmdbResponseDTO>(content);

                    return Ok(movieRecommendationResponse.Results);
                }
                else
                {
                    return BadRequest("Failed to fetch movie recommendations from TMDb.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching movie recommendations.");
            }
        }

    }
}

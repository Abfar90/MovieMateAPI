using MovieMateAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace MovieMateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieMateDbContext _context;

        public MovieController(MovieMateDbContext context)
        {
            _context = context; 
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
                Select(m => new {
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
                                           //.Include(userInfo => userInfo.User)
                                           .ToListAsync();
            return Ok(UserMovies);
        }

        //GET: api/Genres
        [HttpGet]
        [Route("Genre/{id}")]
        public async Task<ActionResult<List<Genre>>> GetUserGenres(int id)
        {
            return Ok(await _context.UserGenres.Where(x => x.UserId == id).Include(g => g.Genre).
                Select(g => new {
                Title = g.Genre.Title,
                Description = g.Genre.Description,
            }).ToListAsync());
        }

        //PUT: api/Edit
        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult<List<Movie>>> RateMovie(Movie ratemovie)
        {
            //var dbmovie = await _context.Movies.FindAsync(ratemovie.MovieDetailsId);
            var dbmovie = await _context.Movies.Where(b => b.MovieDetailsId == ratemovie.MovieDetailsId).FirstAsync();

            if (dbmovie == null) return BadRequest("Movie not found");

            dbmovie.MovieDetailsId = ratemovie.MovieDetailsId;
            dbmovie.Id = ratemovie.Id;
            dbmovie.Rating = ratemovie.Rating;
            dbmovie.UserId = ratemovie.UserId;
            dbmovie.MovieDetails = ratemovie.MovieDetails;

            return Ok(await _context.Movies.Where(x => x.UserId == ratemovie.UserId)
                                           .Include(m => m.MovieDetails)
                                            .Select(g => new {
                                               Title = g.MovieDetails.Title,
                                               rating = g.Rating,
                                           }).ToListAsync());

        }
    }
}

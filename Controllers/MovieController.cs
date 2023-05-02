using MovieMateAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        [Route("User/{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetUserByID(int id)
        {
            return Ok(await _context.Users.Where(x => x.UserId == id).ToListAsync());
            //visa namn på personen, vilka genrer de gillar, vilka filmer de sparat
        }

        // GET: api/Users/Movies
        [HttpGet]
        [Route("Movies/{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetUserMovies(int id)
        {
            return Ok(await _context.Movies.Where(x => x.UserId == id).Include(m => m.MovieNavigation).Include(u => u.User).ToListAsync());
        }

        //GET: api/Genres
        [HttpGet]
        [Route("Genre/{id}")]
        public async Task<ActionResult<List<Genre>>> GetUserGenres(int id)
        {
            return Ok(await _context.UserGenres.Where(x => x.UserId == id).Include(g => g.Genre).Include(u => u.User).ToListAsync());
        }
    }
}

using MovieMateAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MovieMateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private MovieMateDbContext _context;

        public MovieController()
        {
            _context = new MovieMateDbContext(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movie>>> GetUserMovies(int id)
        {
            return Ok(await _context.Movies.Where(x => x.UserId == id).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movie>>> GetUserGenres(int id)
        {
            return Ok(await _context.UserGenres.Where(x => x.UserId == id).ToListAsync());
        }
    }
}

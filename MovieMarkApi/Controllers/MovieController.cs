using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMarkApi.Entity;

namespace MovieMarkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieMarkContext _context;

        public MovieController(MovieMarkContext context)
        {
            _context = context;
        }

        [HttpGet("Get/{userId}")]
        public async Task<ActionResult<Movie>> Get([FromRoute] int userId)
        {
            var movies = await _context.Set<Movie>().Where(w => (w.Access == 1 || w.Access == userId) && !w.IsDeleted).ToListAsync();
            return Ok(movies);
        }

        [HttpGet("WatchMovie/{id}")]
        public async Task<ActionResult> WatchMovie([FromRoute] int id)
        {
            if (!_context.Set<Movie>().Any())
            {
                return NotFound();
            }
            var movie = await _context.Set<Movie>().FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            movie.WatchedOn = DateTime.Now;
            movie.IsWatched = true;
            _context.Set<Movie>().Update(movie);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("PostMovie")]
        public async Task<ActionResult> PostMovie([FromBody] Movie movie)
        {
            _context.Set<Movie>().Add(movie);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<ActionResult> DeleteMovie([FromRoute] int id)
        {
            if (!_context.Set<Movie>().Any())
            {
                return NotFound();
            }
            var movie = await _context.Set<Movie>().FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            movie.IsDeleted = true;
            _context.Set<Movie>().Update(movie);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}

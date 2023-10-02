using Microsoft.AspNetCore.Mvc;
using MovieMarkApi.Entity;

namespace MovieMarkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MovieMarkContext _context;

        public UserController(MovieMarkContext context)
        {
            _context = context;
        }

        [HttpGet("Login/{username}/{password}")]
        public ActionResult<int> Login([FromRoute] string username, [FromRoute] string password)
        {
            if (!_context.Set<User>().Any())
            {
                return 0;
            }
            if (_context.Set<User>().Any(a => a.Username == username && a.Password == password))
            {
                int id = _context.Set<User>().FirstOrDefault(a => a.Username == username && a.Password == password).Id;
                return id;
            } 
            else
            {
                return 0;
            }
        }
      
    }
}

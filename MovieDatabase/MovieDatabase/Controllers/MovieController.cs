using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _MovieRepository;
        public MovieController(IMovieRepository MovieRepository)
        {
            _MovieRepository = MovieRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Movie>))]
        public IActionResult GetMovies()
        {
            var movies = _MovieRepository.GetMovies();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movies);
        }
    }
}
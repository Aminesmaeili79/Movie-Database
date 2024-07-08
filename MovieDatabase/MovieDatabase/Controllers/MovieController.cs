using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    // Route attribute specifies the URL path to access the controller
    [Route("api/[controller]")]
    // ApiController attribute specifies that the class is an API controller
    [ApiController]
    public class MovieController : Controller
    {
        // Dependency injection of IMovieRepository
        private readonly IMovieRepository _MovieRepository;
        // Constructor to initialize IMovieRepository
        public MovieController(IMovieRepository MovieRepository)
        {
            _MovieRepository = MovieRepository;
        }
        // GetMovies method to retrieve a collection of movies from the repository
        [HttpGet]
        // ProducesResponseType attribute specifies the response type and status code
        [ProducesResponseType(200, Type=typeof(IEnumerable<Movie>))]
        // IActionResult return type allows for returning different types of results
        public IActionResult GetMovies()
        {
            // GetMovies method from IMovieRepository is called to retrieve movies
            var movies = _MovieRepository.GetMovies();
            // If the model state is not valid, return a bad request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movies);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    // Route attribute specifies the URL path to access the controller
    [Route("api/[controller]")]
    // ApiController attribute specifies that the class is an API controller
    [ApiController]
    public class TheaterController : ControllerBase
    {
        // Dependency injection of ITheaterRepository
        private readonly ITheaterRepository _TheaterRepository;
        // Constructor to initialize ITheaterRepository
        public TheaterController(ITheaterRepository TheaterRepository)
        {
            _TheaterRepository = TheaterRepository;
        }
        // GetTheaters method to retrieve a collection of theaters from the repository
        [HttpGet]
        // ProducesResponseType attribute specifies the response type and status code
        [ProducesResponseType(200, Type = typeof(IEnumerable<Theater>))]
        // IActionResult return type allows for returning different types of results
        public IActionResult GetTheaters()
        {
            // GetTheaters method from ITheaterRepository is called to retrieve theaters
            var Theaters = _TheaterRepository.GetTheaters();
            // If the model state is not valid, return a bad request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Theaters);
        }
    }
}
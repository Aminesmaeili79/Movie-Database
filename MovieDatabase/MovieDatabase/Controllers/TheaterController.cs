using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterRepository _TheaterRepository;

        public TheaterController(ITheaterRepository TheaterRepository)
        {
            _TheaterRepository = TheaterRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Theater>))]
        public IActionResult GetTheaters()
        {
            var Theaters = _TheaterRepository.GetTheaters();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Theaters);
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Dto;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
using MovieDatabase.Repositories;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterRepository _TheaterRepository;
        private readonly IMapper _mapper;

        public TheaterController(ITheaterRepository TheaterRepository, IMapper mapper)
        {
            _TheaterRepository = TheaterRepository;
            _mapper = mapper;
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

        [HttpPost]
        public IActionResult CreateTheater([FromBody] TheaterDto theaterCreate)
        {
            if (theaterCreate == null)
                return BadRequest(ModelState);

            var theaterExists = _TheaterRepository.GetTheaters()
                .Any(t => t.Name.Trim().ToUpper() == theaterCreate.Name.TrimEnd().ToUpper());

            if (theaterExists)
            {
                ModelState.AddModelError("", "Theater already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var theaterMap = _mapper.Map<Theater>(theaterCreate);

            if (!_TheaterRepository.CreateTheater(theaterMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the theater {theaterCreate.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
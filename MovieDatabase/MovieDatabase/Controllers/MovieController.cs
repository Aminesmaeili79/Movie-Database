using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
using MovieDatabase.Dto;
using System.Collections.Generic;
using MovieDatabase.Repositories;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _MovieRepository;
        private readonly IMapper _mapper;
        private readonly IWorkerRepository _WorkerRepository;
        public MovieController(IMovieRepository MovieRepository, IMapper mapper, IWorkerRepository workerRepository)
        {
            _MovieRepository = MovieRepository;
            _mapper = mapper;
            _WorkerRepository = workerRepository;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _mapper.Map<List<MovieDto>>(_MovieRepository.GetMovies());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovieById(int movieId)
        {
            var movie = _mapper.Map<List<MovieDto>>(_MovieRepository.GetMovieById(movieId));

            if (movie == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieDto movieCreate)
        {
            if (movieCreate == null)
                return BadRequest(ModelState);

            var movieExists = _MovieRepository.GetMovies()
                .Any(m => m.Title.Trim().ToUpper() == movieCreate.Title.TrimEnd().ToUpper());

            if (movieExists)
            {
                ModelState.AddModelError("", "Movie already exists");
                return StatusCode(422, ModelState);
            }

            var director = _WorkerRepository.GetWorkerById(movieCreate.DirectorId);

            if (director == null || director.Role != Role.Director)
            {
                ModelState.AddModelError("DirectorId", "The entered director ID is not a director or isn't valid.");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieMap = _mapper.Map<Movie>(movieCreate);

            if (!_MovieRepository.CreateMovie(movieMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the movie {movieCreate.Title}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
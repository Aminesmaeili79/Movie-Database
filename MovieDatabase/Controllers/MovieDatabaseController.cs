using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Data;
using MovieDatabase.Models;
using MovieDatabase.Controllers;
using MovieDatabase.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDatabaseController : ControllerBase
    {
        private readonly DataContext _context;

        public MovieDatabaseController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> CreateMovie(MovieCreateDTO request)
        {
            var newMovie = new Movie
            {
                Title = request.Title,
                ReleaseDate = request.ReleaseDate,
            };

            var workers = request.Workers.Select(w => new Worker { FirstName = w.FirstName, LastName = w.LastName, Movies = new List<Movie> { newMovie } }).ToList();
            var theaters = request.Theaters.Select(t => new Theater { Name = t.Name, Location = t.Location ,MoviesList = new List<Movie> { newMovie } }).ToList();

            newMovie.Workers = workers;
            newMovie.Theaters = theaters;

            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();

            return Ok(await _context.Movies.Include(m => m.Workers).Include(m => m.Theaters).ToListAsync());
        }
    }
}

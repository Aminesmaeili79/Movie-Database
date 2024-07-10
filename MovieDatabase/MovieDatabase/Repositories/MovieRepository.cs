using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Data;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Repositories
{
    // MovieRepository class implements IMovieRepository
    public class MovieRepository : IMovieRepository
    {
        // MovieDbContext is injected into the repository
        private readonly MovieDbContext _context;
        // Constructor to initialize MovieDbContext
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        // GetMovies method retrieves a collection of movies from the database
        public List<Movie> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Director)
                .Include(m => m.ActorMovies)
                    .ThenInclude(am => am.Actor)
                .Include(m => m.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .OrderBy(m => m.Id)
                .ToList();
        }
    }
}
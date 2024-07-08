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
        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Id).ToList();
        }
    }
}
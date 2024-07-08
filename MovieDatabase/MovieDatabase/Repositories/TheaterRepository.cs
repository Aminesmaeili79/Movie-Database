using MovieDatabase.Data;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Repositories
{
    // TheaterRepository class implements ITheaterRepository
    public class TheaterRepository : ITheaterRepository
    {
        // MovieDbContext is injected into the repository
        private readonly MovieDbContext _context;
        // Constructor to initialize MovieDbContext
        public TheaterRepository(MovieDbContext context)
        {
            _context = context;
        }
        // GetTheaters method retrieves a collection of theaters from the database
        public ICollection<Theater> GetTheaters()
        {
            return _context.Theaters.OrderBy(t => t.Id).ToList();
        }
    }
}
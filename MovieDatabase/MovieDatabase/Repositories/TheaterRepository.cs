using Microsoft.EntityFrameworkCore;
using MovieDatabase.Data;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly MovieDbContext _context;

        public TheaterRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<Theater> GetTheaters()
        {
            return _context.Theaters
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Movie)
                .OrderBy(t => t.Id)
                .ToList();
        }
    }
}
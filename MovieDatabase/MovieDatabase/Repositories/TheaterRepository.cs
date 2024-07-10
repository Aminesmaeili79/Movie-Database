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
                    .ThenInclude(tm => tm.Movie)
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .OrderBy(t => t.Id)
                .ToList();
        }

        public Theater GetTheaterById(int id)
        {
            return _context.Theaters
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Movie)
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .OrderBy(t => t.Id)
                .FirstOrDefault(t => t.Id == id);
        }
    }
}
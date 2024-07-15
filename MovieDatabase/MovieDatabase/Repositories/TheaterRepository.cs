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
                .Where(t => t.Id == id)
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Movie)
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .FirstOrDefault();
        }

        public Theater GetTheaterByName(string name)
        {
            return _context.Theaters
                .Where(t => t.Name.ToLower() == name.ToLower())
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Movie)
                .Include(t => t.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .FirstOrDefault();
        }

        public bool CreateTheater(Theater theater)
        {
            _context.Add(theater);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool UpdateTheater(Theater theater)
        {
            _context.Update(theater);
            return Save();
        }
    }
}
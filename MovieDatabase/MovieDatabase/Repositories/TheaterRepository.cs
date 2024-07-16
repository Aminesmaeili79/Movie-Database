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
                //.Include(t => t.TheaterMovies)
                //    .ThenInclude(tm => tm.Movie)
                //.Include(t => t.TheaterMovies)
                //    .ThenInclude(tm => tm.Theater)
                .OrderBy(t => t.Id)
                .ToList();
        }

        public Theater GetTheaterById(int id)
        {
            return _context.Theaters
                //.Include(t => t.TheaterMovies)
                //    .ThenInclude(tm => tm.Movie)
                //.Include(t => t.TheaterMovies)
                //    .ThenInclude(tm => tm.Theater)
                .FirstOrDefault(t => t.Id == id);
        }

        //public Theater GetTheaterByName(string name)
        //{
        //    return _context.Theaters
        //        .Where(t => t.Name.ToLower() == name.ToLower())
        //        .Include(t => t.TheaterMovies)
        //            .ThenInclude(tm => tm.Movie)
        //        .Include(t => t.TheaterMovies)
        //            .ThenInclude(tm => tm.Theater)
        //        .FirstOrDefault();
        //}

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
            var existingEntity = _context.Theaters.Find(theater.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(theater).State = EntityState.Modified;
            _context.Update(theater);
            return Save();
        }

        public bool DeleteTheater(Theater theater)
        {
            var theaterMovies = _context.TheaterMovies.Where(tm => tm.TheaterId == theater.Id).ToList();

            // Remove the associated TheaterMovie entities
            _context.TheaterMovies.RemoveRange(theaterMovies);

            _context.Remove(theater);
            return Save();
        }
    }
}
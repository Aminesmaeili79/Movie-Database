using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Data;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

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

        public Movie GetMovieById(int id)
        {
            return _context.Movies
                .Include(m => m.Director)
                .Include(m => m.ActorMovies)
                    .ThenInclude(am => am.Actor)
                .Include(m => m.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .OrderBy(m => m.Id)
                .FirstOrDefault(m => m.Id == id);
        }

    }
}
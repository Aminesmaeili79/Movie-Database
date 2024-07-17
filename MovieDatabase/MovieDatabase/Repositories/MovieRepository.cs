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
                .Where(m => m.Id == id)
                .Include(m => m.Director)
                .Include(m => m.ActorMovies)
                    .ThenInclude(am => am.Actor)
                .Include(m => m.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .FirstOrDefault();
        }

        public Movie GetMovieByTitle(string title)
        {
            return _context.Movies
                .Where(m => m.Title.ToLower() == title.ToLower())
                .Include(m => m.Director)
                .Include(m => m.ActorMovies)
                    .ThenInclude(am => am.Actor)
                .Include(m => m.TheaterMovies)
                    .ThenInclude(tm => tm.Theater)
                .FirstOrDefault();
        }

        public bool CreateMovie(Movie movie)
        {
            _context.Add(movie);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateMovie(Movie movie)
        {
            var existingEntity = _context.Movies.Find(movie.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(movie).State = EntityState.Modified;
            _context.Update(movie);
            return Save();
        }

        public bool DeleteMovie(Movie movie)
        {
            _context.Remove(movie);
            return Save();
        }
    }
}
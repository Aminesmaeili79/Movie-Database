using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IMovieRepository
    {
        // GetMovies method to retrieve a collection of movies
        ICollection<Movie> GetMovies();
    }
}
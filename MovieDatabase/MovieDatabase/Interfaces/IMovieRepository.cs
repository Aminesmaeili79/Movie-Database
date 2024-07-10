using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int id);
    }
}
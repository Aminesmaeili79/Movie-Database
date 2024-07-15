using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int id);
        Movie GetMovieByTitle(string title);
        bool CreateMovie(Movie movie);
        bool Save();
    }
}
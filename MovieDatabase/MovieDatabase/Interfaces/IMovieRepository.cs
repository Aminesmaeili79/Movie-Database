using MovieDatabase.Dto;
using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int id);
        Movie GetMovieByTitle(string title);
        Movie GetMoviesTrimToUpper(MovieDto movieCreate);
        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(Movie movie);
        bool Save();
    }
}
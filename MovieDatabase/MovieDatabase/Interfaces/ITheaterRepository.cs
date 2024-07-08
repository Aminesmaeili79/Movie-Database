using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface ITheaterRepository
    {
        // GetTheaters method to retrieve a collection of theaters
        ICollection<Theater> GetTheaters();
    }
}
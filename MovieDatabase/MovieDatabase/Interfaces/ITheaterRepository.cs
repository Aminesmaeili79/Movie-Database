using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface ITheaterRepository
    {
        List<Theater> GetTheaters();
        Theater GetTheater(int id);
    }
}
using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface ITheaterRepository
    {
        List<Theater> GetTheaters();
        Theater GetTheaterById(int id);
        bool CreateTheater(Theater theater);
        bool UpdateTheater(Theater theater);
        bool DeleteTheater(Theater theater);
        bool Save();
    }
}
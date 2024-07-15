using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface ITheaterRepository
    {
        List<Theater> GetTheaters();
        Theater GetTheaterById(int id);
        Theater GetTheaterByName(string name);
        bool CreateTheater(Theater theater);
        bool UpdateTheater(Theater theater);
        bool Save();
    }
}
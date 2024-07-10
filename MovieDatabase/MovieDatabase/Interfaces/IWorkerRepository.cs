using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IWorkerRepository
    {
        List<Worker> GetWorkers();
    }
}
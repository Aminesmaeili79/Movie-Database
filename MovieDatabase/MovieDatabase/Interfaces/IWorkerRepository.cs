using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IWorkerRepository
    {
        // GetWorkers method to retrieve a collection of workers
        ICollection<Worker> GetWorkers();
    }
}
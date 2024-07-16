using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IWorkerRepository
    {
        List<Worker> GetWorkers();
        Worker GetWorkerById(int id);
        bool CreateWorker(Worker worker);
        bool UpdateWorker(Worker worker);
        bool DeleteWorker(Worker worker);
        bool Save();
    }
}
using MovieDatabase.Models;

namespace MovieDatabase.Interfaces
{
    public interface IWorkerRepository
    {
        List<Worker> GetWorkers();
        Worker GetWorkerById(int id);
        Worker GetWorkerByName(string name);
        bool CreateWorker(Worker worker);
        bool UpdateWorker(Worker worker);
        bool Save();
    }
}
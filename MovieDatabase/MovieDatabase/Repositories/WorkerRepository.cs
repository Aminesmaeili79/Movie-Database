using MovieDatabase.Data;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Repositories
{
    // WorkerRepository class implements ITheaterRepository
    public class WorkerRepository : IWorkerRepository
    {
        // MovieDbContext is injected into the repository
        private readonly MovieDbContext _context;
        // Constructor to initialize MovieDbContext
        public WorkerRepository(MovieDbContext context)
        {
            _context = context;
        }
        // GetWorkers method retrieves a collection of workers from the database
        public ICollection<Worker> GetWorkers()
        {
            return _context.Workers.OrderBy(t => t.Id).ToList();
        }
    }
}
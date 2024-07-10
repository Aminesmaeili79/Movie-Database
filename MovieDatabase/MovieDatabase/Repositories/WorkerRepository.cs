using Microsoft.EntityFrameworkCore;
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
        public List<Worker> GetWorkers()
        {
            return _context.Workers
                .Include(w => w.Role)
                .Include(w => w.Movies)
                .Include(w => w.ActorMovies)
                    .ThenInclude(am => am.Movie)
                .Include(w => w.ActorMovies)
                    .ThenInclude(am => am.Actor)
                .OrderBy(w => w.Id)
                .ToList();
        }
    }
}
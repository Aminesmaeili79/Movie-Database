using Microsoft.EntityFrameworkCore;
using MovieDatabase.Data;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly MovieDbContext _context;

        public WorkerRepository(MovieDbContext context)
        {
            _context = context;
        }

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
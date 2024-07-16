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
                //.Include(w => w.Movies)
                //.Include(w => w.ActorMovies)
                //    .ThenInclude(am => am.Movie)
                //.Include(w => w.ActorMovies)
                //    .ThenInclude(am => am.Actor)
                .OrderBy(w => w.Id)
                .ToList();
        }

        public Worker GetWorkerById(int id)
        {
            return _context.Workers
                //.Include(w => w.Movies)
                //.Include(w => w.ActorMovies)
                //    .ThenInclude(am => am.Movie)
                //.Include(w => w.ActorMovies)
                //    .ThenInclude(am => am.Actor)
                .FirstOrDefault(w => w.Id == id);
        }

        //public Worker GetWorkerByName(string name)
        //{
        //    return _context.Workers
        //       .Where(w => w.FirstName.ToLower() + " " + w.LastName.ToLower() == name.ToLower())
        //        .Include(w => w.Role)
        //        .Include(w => w.Movies)
        //        .Include(w => w.ActorMovies)
        //            .ThenInclude(am => am.Movie)
        //        .Include(w => w.ActorMovies)
        //           .ThenInclude(am => am.Actor)
        //       .FirstOrDefault();
        //}

        public bool CreateWorker(Worker worker)
        {
            _context.Add(worker);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool UpdateWorker(Worker worker)
        {
            var existingEntity = _context.Workers.Find(worker.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.Entry(worker).State = EntityState.Modified;
            _context.Update(worker);
            return Save();
        }

        public bool DeleteWorker(Worker worker) {
            // Query for related entities
            var actorMovies = _context.ActorMovies.Where(am => am.ActorId == worker.Id).ToList();
            var theaterMovies = _context.TheaterMovies.Where(tm => tm.TheaterId == worker.Id).ToList();

            // Remove the related entities
            _context.ActorMovies.RemoveRange(actorMovies);
            _context.TheaterMovies.RemoveRange(theaterMovies);

            var directedMovies = _context.Movies.Where(m => m.DirectorId == worker.Id).ToList();
            _context.Movies.RemoveRange(directedMovies); // Delete movies

            // Now remove the Worker entity
            _context.Workers.Remove(worker);

            return Save();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using TrackingAPI.Models;

namespace TrackingAPI.Data
{
    public class WorkerDbContext : DbContext
    {
        public WorkerDbContext(DbContextOptions<WorkerDbContext> options)
            : base(options) { }

        public DbSet<Worker> Workers { get; set; }
    }
}

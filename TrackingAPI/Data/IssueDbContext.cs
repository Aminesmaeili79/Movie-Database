using Microsoft.EntityFrameworkCore;
using TrackingAPI.Models;

namespace TrackingAPI.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            : base(options) { }

        public DbSet<Movie> Issues { get; set; }
        public DbSet<Theater> Theater { get; set; }
        public DbSet<Worker> Worker { get; set; }
    }
}

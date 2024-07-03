using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models;

namespace MovieDatabase.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Theater> Theaters { get; set; }
    }
}

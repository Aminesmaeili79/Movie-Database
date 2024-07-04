using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models;

namespace MovieDatabase.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}

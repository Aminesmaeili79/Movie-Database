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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasKey(m => new { m.Id });

            // Movie - Director relationship
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(mi => mi.DirectorId);

            // Movie - Actors relationship
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(d => d.Movies);

            // Movie - Theaters relationship
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Theaters)
                .WithMany(d => d.Movies);
        }

    }
}

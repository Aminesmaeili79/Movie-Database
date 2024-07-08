using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models;

namespace MovieDatabase.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        // DbSet properties for each entity in the database
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<TheaterMovie> TheaterMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many relationship between Worker and Movie
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });
            // One-to-many relationship between Worker and ActorMovie
            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId)
                .OnDelete(DeleteBehavior.NoAction);
            // One-to-many relationship between Movie and ActorMovie
            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            // Many-to-many relationship between Theater and Movie
            modelBuilder.Entity<TheaterMovie>()
                .HasKey(tm => new { tm.TheaterId, tm.MovieId });
            // One-to-many relationship between Theater and TheaterMovie
            modelBuilder.Entity<TheaterMovie>()
                .HasOne(tm => tm.Theater)
                .WithMany(t => t.TheaterMovies)
                .HasForeignKey(tm => tm.TheaterId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // One-to-many relationship between Movie and TheaterMovie
            modelBuilder.Entity<TheaterMovie>()
                .HasOne(tm => tm.Movie)
                .WithMany(m => m.TheaterMovies)
                .HasForeignKey(tm => tm.MovieId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}

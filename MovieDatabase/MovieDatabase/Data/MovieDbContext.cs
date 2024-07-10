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
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<TheaterMovie> TheaterMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TheaterMovie>()
                .HasKey(tm => new { tm.TheaterId, tm.MovieId });

            modelBuilder.Entity<TheaterMovie>()
                .HasOne(tm => tm.Theater)
                .WithMany(t => t.TheaterMovies)
                .HasForeignKey(tm => tm.TheaterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TheaterMovie>()
                .HasOne(tm => tm.Movie)
                .WithMany(m => m.TheaterMovies)
                .HasForeignKey(tm => tm.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(w => w.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

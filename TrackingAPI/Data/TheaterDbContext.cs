using Microsoft.EntityFrameworkCore;
using TrackingAPI.Models;

namespace TrackingAPI.Data
{
    public class TheaterDbContext : DbContext
    {
        public TheaterDbContext(DbContextOptions<TheaterDbContext> options)
            : base(options) { }

        public DbSet<Theater> Theaters { get; set; }
    }
}

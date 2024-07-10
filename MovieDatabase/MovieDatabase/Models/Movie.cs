namespace MovieDatabase.Models
{
    public class Movie
    {
        // Properties for the Movie entity
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        // Foreign key for the Director navigation property
        public int DirectorId { get; set; }
        public Worker Director { get; set; }
        // Navigation property for the many-to-many relationship between Worker and Movie
        public ICollection<ActorMovie> ActorMovies { get; set; }
        // Navigation property for the many-to-many relationship between Theater and Movie
        public ICollection<TheaterMovie> TheaterMovies { get; set; }
    }
}
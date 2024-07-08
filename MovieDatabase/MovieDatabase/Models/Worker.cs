namespace MovieDatabase.Models
{
    public class Worker
    {
        // Properties for the Worker entity
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        // Navigation property for the many-to-many relationship between Worker and Movie
        public ICollection<Movie> Movies { get; set; }
        // Navigation property for the one-to-many relationship between Worker and ActorMovie
        public ICollection<ActorMovie> ActorMovies { get; set; }
    }
}

namespace MovieDatabase.Models
{
    public class Theater
    {
        // Properties for the Theater entity
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        // Navigation property for the many-to-many relationship between Theater and Movie
        public ICollection<TheaterMovie> TheaterMovies { get; set; }
    }
}

namespace MovieDatabase.Models
{
    public class TheaterMovie
    {
        // Properties for the TheaterMovie entity
        // Foreign key for the Movie navigation property
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        // Foreign key for the Theater navigation property
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }
    }
}
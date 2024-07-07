namespace MovieDatabase.Models

{
    public class ActorMovie
    {
        // Properties for the ActorMovie entity
        // Foreign key for the Movie navigation property
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        // Foreign key for the Worker navigation property
        public int ActorId { get; set; }
        public Worker Actor { get; set; }
    }
}
namespace MovieDatabase.Models

{
    public class ActorMovie
    {
        // Properties for the ActorMovie entity
        // Foreign key for the Movie navigation property
        public virtual int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        // Foreign key for the Worker navigation property
        public virtual int ActorId { get; set; }
        public virtual Worker Actor { get; set; }
    }
}
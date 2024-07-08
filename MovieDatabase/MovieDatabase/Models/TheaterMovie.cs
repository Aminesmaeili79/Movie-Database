namespace MovieDatabase.Models
{
    public class TheaterMovie
    {
        // Properties for the TheaterMovie entity
        // Foreign key for the Movie navigation property
        public virtual int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        // Foreign key for the Theater navigation property
        public virtual int TheaterId { get; set; }
        public virtual Theater Theater { get; set; }
    }
}
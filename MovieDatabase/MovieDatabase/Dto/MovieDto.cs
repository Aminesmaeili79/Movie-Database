namespace MovieDatabase.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public int DirectorId { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Theaters { get; set; }
    }
}

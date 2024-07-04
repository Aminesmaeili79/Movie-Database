namespace MovieDatabase.Models
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Movie> Movies { get; set; }
    }
}

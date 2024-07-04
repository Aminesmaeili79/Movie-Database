using Microsoft.AspNetCore.Mvc;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Worker> Actors { get; set; }
        public int DirectorId { get; set; }
        public Worker Director { get; set; }
        public List<Theater> Theaters { get; set; }
    }
}
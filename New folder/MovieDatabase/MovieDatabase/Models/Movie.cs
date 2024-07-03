using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public DateTime ReleaseDate { get; set; }
        [JsonIgnore]
        public List<Worker> Workers { get; set; }
        [JsonIgnore]
        public List<Theater> Theaters { get; set; }
    }
}

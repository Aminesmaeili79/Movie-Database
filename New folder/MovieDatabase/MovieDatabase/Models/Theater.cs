using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieDatabase.Models
{
    public class Theater
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public string Location { get; set; }
        [JsonIgnore]
        public List<Movie> MoviesList { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieDatabase.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string LastName { get; set; }
        [JsonIgnore]
        public List<Movie> Movies { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
    }

    public enum Role
    {
        Director, Actor
    }
}
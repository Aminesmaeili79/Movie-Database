using System.ComponentModel.DataAnnotations;

namespace TrackingAPI.Models
{
    public class Theater
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string[] MoviesList { get; set; }
        public string Movie { get; set; }
    }
}

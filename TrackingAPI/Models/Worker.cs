using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TrackingAPI.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Role Role { get; set; }
    }

    public enum Role
    {
        Director, Actor
    }
}
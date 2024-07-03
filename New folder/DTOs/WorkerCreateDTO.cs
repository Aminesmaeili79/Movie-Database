using MovieDatabase.Models;

namespace MovieDatabase.DTOs
{
    public record struct WorkerCreateDTO(string FirstName, string LastName, List<MovieCreateDTO> Movies, Role Role);
}

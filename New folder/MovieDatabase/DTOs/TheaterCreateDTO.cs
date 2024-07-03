namespace MovieDatabase.DTOs
{
    public record struct TheaterCreateDTO(string Name, string Location, List<MovieCreateDTO> MoviesList);
}

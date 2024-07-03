namespace MovieDatabase.DTOs
{
    public record struct MovieCreateDTO(string Title, DateTime ReleaseDate, List<WorkerCreateDTO> Workers, List<TheaterCreateDTO> Theaters);
}

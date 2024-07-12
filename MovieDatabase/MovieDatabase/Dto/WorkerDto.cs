using MovieDatabase.Models;

namespace MovieDatabase.Dto
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
    }
}

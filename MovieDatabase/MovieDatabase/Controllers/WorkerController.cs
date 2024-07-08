using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    // Route attribute specifies the URL path to access the controller
    [Route("api/[controller]")]
    // ApiController attribute specifies that the class is an API controller
    [ApiController]
    public class WorkerController : ControllerBase
    {
        // Dependency injection of IWorkerRepository
        private readonly IWorkerRepository _WorkerRepository;
        // Constructor to initialize IWorkerRepository
        public WorkerController(IWorkerRepository WorkerRepository)
        {
            _WorkerRepository = WorkerRepository;
        }
        // GetWorkers method to retrieve a collection of workers from the repository
        [HttpGet]
        // ProducesResponseType attribute specifies the response type and status code
        [ProducesResponseType(200, Type = typeof(IEnumerable<Worker>))]
        // IActionResult return type allows for returning different types of results
        public IActionResult GetWorkers()
        {
            // GetWorkers method from IWorkerRepository is called to retrieve workers
            var workers = _WorkerRepository.GetWorkers();
            // If the model state is not valid, return a bad request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workers);
        }
    }
}
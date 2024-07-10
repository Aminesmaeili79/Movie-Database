using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository _WorkerRepository;

        public WorkerController(IWorkerRepository WorkerRepository)
        {
            _WorkerRepository = WorkerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Worker>))]
        public IActionResult GetWorkers()
        {
            var workers = _WorkerRepository.GetWorkers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workers);
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Dto;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
using MovieDatabase.Repositories;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository _WorkerRepository;
        private readonly IMapper _mapper;

        public WorkerController(IWorkerRepository WorkerRepository, IMapper mapper)
        {
            _WorkerRepository = WorkerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWorkers()
        {
            var workers = _WorkerRepository.GetWorkers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workers);
        }

        [HttpPost]
        public IActionResult CreateWorker([FromBody] WorkerDto workerCreate)
        {
            if (workerCreate == null)
                return BadRequest(ModelState);

            var workerFirstNameExists = _WorkerRepository.GetWorkers()
                .Any(m => m.FirstName.Trim().ToUpper() == workerCreate.FirstName.TrimEnd().ToUpper());
            var workerLastNameExists = _WorkerRepository.GetWorkers()
                .Any(m => m.LastName.Trim().ToUpper() == workerCreate.LastName.TrimEnd().ToUpper());
            var workerFullNameExists = _WorkerRepository.GetWorkers()
                .Any(m => m.FirstName.Trim().ToUpper() + " " + m.LastName.Trim().ToUpper()
                == workerCreate.FirstName.TrimEnd().ToUpper() + " " + workerCreate.LastName.TrimEnd().ToUpper());

            if (workerFirstNameExists || workerLastNameExists || workerFullNameExists)
            {
                ModelState.AddModelError("", "Worker already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var workerMap = _mapper.Map<Worker>(workerCreate);

            if (!_WorkerRepository.CreateWorker(workerMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the worker {workerCreate.FirstName} {workerCreate.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{workerId}")]
        public IActionResult UpdateWorker(int workerId, [FromBody] WorkerDto workerUpdate)
        {
            if (workerUpdate == null)
                return BadRequest(ModelState);

            var worker = _WorkerRepository.GetWorkerById(workerId);

            if (worker == null)
                return NotFound();

            var workerFirstNameExists = _WorkerRepository.GetWorkers()
                .Any(m => m.FirstName.Trim().ToUpper() == workerUpdate.FirstName.TrimEnd().ToUpper());
            var workerLastNameExists = _WorkerRepository.GetWorkers()
                .Any(m => m.LastName.Trim().ToUpper() == workerUpdate.LastName.TrimEnd().ToUpper());
            var workerFullNameExists = _WorkerRepository.GetWorkers()
                .Any(m => m.FirstName.Trim().ToUpper() + " " + m.LastName.Trim().ToUpper()
                == workerUpdate.FirstName.TrimEnd().ToUpper() + " " + workerUpdate.LastName.TrimEnd().ToUpper());

            if (workerFirstNameExists || workerLastNameExists || workerFullNameExists)
            {
                ModelState.AddModelError("", "Worker already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var workerMap = _mapper.Map<Worker>(workerUpdate);

            if (!_WorkerRepository.UpdateWorker(workerMap))
            {
                ModelState.AddModelError("", $"Something went wrong updating the worker {workerUpdate.FirstName} {workerUpdate.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{workerId}")]
        public IActionResult DeleteWorker(int workerId)
        {
            var worker = _WorkerRepository.GetWorkerById(workerId);

            if (worker == null)
                return NotFound();

            if (!_WorkerRepository.DeleteWorker(worker))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the worker {worker.FirstName} {worker.LastName}");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Successfully deleted");
        }
    }
}
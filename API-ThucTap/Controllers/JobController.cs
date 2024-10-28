using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobAll()
        {
            var job = await _jobService.GetAllJobAsync();
            return Ok(job);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobId(int id)
        {
            var job = await _jobService.GetJobAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob(Job job)
        {
            await _jobService.AddJobAsync(job);
            return CreatedAtAction(nameof(GetJobAll), new { id = job.JobId }, job);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, Job job)
        {
            if (id != job.JobId)
            {
                return BadRequest();
            }

            await _jobService.UpdateJobAsync(job);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _jobService.DeleteJobAsync(id);
            return NoContent();
        }
    }
}

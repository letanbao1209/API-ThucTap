using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitScheduleController : ControllerBase
    {
        private readonly IVisitScheduleService _visitScheduleService;
        public VisitScheduleController(IVisitScheduleService visitScheduleService)
        {
            _visitScheduleService = visitScheduleService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitSchedule>>> GetVisitScheduleAll()
        {
            var visitSchedule = await _visitScheduleService.GetAllVisitScheduleAsync();
            return Ok(visitSchedule);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VisitSchedule>> GetVisitScheduleId(int id)
        {
            var visitSchedule = await _visitScheduleService.GetVisitScheduleAsync(id);
            if (visitSchedule == null)
            {
                return NotFound();
            }
            return Ok(visitSchedule);
        }

        [HttpPost]
        public async Task<ActionResult<VisitSchedule>> CreateVisitSchedule(VisitSchedule visitSchedule)
        {
            await _visitScheduleService.AddVisitScheduleAsync(visitSchedule);
            return CreatedAtAction(nameof(GetVisitScheduleAll), new { id = visitSchedule.VisitScheduleId }, visitSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisitSchedule(int id, VisitSchedule visitSchedule)
        {
            if (id != visitSchedule.VisitScheduleId)
            {
                return BadRequest();
            }

            await _visitScheduleService.UpdateVisitScheduleAsync(visitSchedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitSchedule(int id)
        {
            await _visitScheduleService.DeleteVisitScheduleAsync(id);
            return NoContent();
        }
    }
}

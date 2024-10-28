using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreaAll()
        {
            var area = await _areaService.GetAllAreaAsync();
            return Ok(area);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetAreaId(int id)
        {
            var area = await _areaService.GetAreaAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        [HttpPost]
        public async Task<ActionResult<Area>> CreateArea(Area area)
        {
            await _areaService.AddAreaAsync(area);
            return CreatedAtAction(nameof(GetAreaAll), new { id = area.AreaId }, area);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArea(int id, Area area)
        {
            if (id != area.AreaId)
            {
                return BadRequest();
            }

            await _areaService.UpdateAreaAsync(area);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _areaService.DeleteAreaAsync(id);
            return NoContent();
        }
    }
}

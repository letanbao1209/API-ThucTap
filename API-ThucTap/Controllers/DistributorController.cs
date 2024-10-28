using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IDistributorService _distributorService;
        public DistributorController(IDistributorService distributorService)
        {
            _distributorService = distributorService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distributor>>> GetDistributorAll()
        {
            var distributor = await _distributorService.GetAllDistributorAsync();
            return Ok(distributor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Distributor>> GetDistributorId(int id)
        {
            var distributor = await _distributorService.GetDistributorAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }
            return Ok(distributor);
        }

        [HttpPost]
        public async Task<ActionResult<Distributor>> CreateDistributor(Distributor distributor)
        {
            await _distributorService.AddDistributorAsync(distributor);
            return CreatedAtAction(nameof(GetDistributorAll), new { id = distributor.DistributorId }, distributor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDistributor(int id, Distributor distributor)
        {
            if (id != distributor.DistributorId)
            {
                return BadRequest();
            }

            await _distributorService.UpdateDistributorAsync(distributor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistributor(int id)
        {
            await _distributorService.DeleteDistributorAsync(id);
            return NoContent();
        }
    }
}

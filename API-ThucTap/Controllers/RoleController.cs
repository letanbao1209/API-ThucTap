using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoleAll()
        {
            var role = await _roleService.GetAllRoleAsync();
            return Ok(role);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleId(int id)
        {
            var role = await _roleService.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            await _roleService.AddRoleAsync(role);
            return CreatedAtAction(nameof(GetRoleAll), new { id = role.RoleId }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }

            await _roleService.UpdateRoleAsync(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}

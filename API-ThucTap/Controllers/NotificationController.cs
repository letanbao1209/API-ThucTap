using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotificationAll()
        {
            var notification = await _notificationService.GetAllNotificationAsync();
            return Ok(notification);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotificationId(int id)
        {
            var notification = await _notificationService.GetNotificationAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> CreateNotification(Notification notification)
        {
            await _notificationService.AddNotificationAsync(notification);
            return CreatedAtAction(nameof(GetNotificationAll), new { id = notification.NotificationId }, notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, Notification notification)
        {
            if (id != notification.NotificationId)
            {
                return BadRequest();
            }

            await _notificationService.UpdateNotificationAsync(notification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}

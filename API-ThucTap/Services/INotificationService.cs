using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotificationAsync();
        Task<Notification> GetNotificationAsync(int id);
        Task AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
    }
}

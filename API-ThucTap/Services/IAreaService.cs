using API_ThucTap.Models;

namespace API_ThucTap.Services
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetAllAreaAsync();
        Task<Area> GetAreaAsync(int id);
        Task AddAreaAsync(Area area);
        Task UpdateAreaAsync(Area area);
        Task DeleteAreaAsync(int id);
    }
}

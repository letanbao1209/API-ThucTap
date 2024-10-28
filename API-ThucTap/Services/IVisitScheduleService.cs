using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface IVisitScheduleService
    {
        Task<IEnumerable<VisitSchedule>> GetAllVisitScheduleAsync();
        Task<VisitSchedule> GetVisitScheduleAsync(int id);
        Task AddVisitScheduleAsync(VisitSchedule visitSchedule);
        Task UpdateVisitScheduleAsync(VisitSchedule visitSchedule);
        Task DeleteVisitScheduleAsync(int id);
    }
}

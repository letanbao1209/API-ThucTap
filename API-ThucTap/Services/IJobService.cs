using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobAsync();
        Task<Job> GetJobAsync(int id);
        Task AddJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(int id);
    }
}

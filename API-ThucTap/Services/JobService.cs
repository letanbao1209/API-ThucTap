using API_ThucTap.Data;
using API_ThucTap.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ThucTap.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddJobAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Job>> GetAllJobAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobAsync(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task UpdateJobAsync(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
        }
    }
}

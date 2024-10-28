using API_ThucTap.Data;
using API_ThucTap.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ThucTap.Services
{
    public class VisitScheduleService : IVisitScheduleService
    {
        private readonly ApplicationDbContext _context;

        public VisitScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddVisitScheduleAsync(VisitSchedule visitSchedule)
        {
            await _context.VisitSchedules.AddAsync(visitSchedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVisitScheduleAsync(int id)
        {
            var visitSchedule = await _context.VisitSchedules.FindAsync(id);
            if (visitSchedule != null)
            {
                _context.VisitSchedules.Remove(visitSchedule);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VisitSchedule>> GetAllVisitScheduleAsync()
        {
            return await _context.VisitSchedules.ToListAsync();
        }

        public async Task<VisitSchedule> GetVisitScheduleAsync(int id)
        {
            return await _context.VisitSchedules.FindAsync(id);
        }

        public async Task UpdateVisitScheduleAsync(VisitSchedule visitSchedule)
        {
            _context.VisitSchedules.Update(visitSchedule);
            await _context.SaveChangesAsync();
        }
    }
}

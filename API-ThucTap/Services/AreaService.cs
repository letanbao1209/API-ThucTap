using API_ThucTap.Data;
using API_ThucTap.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ThucTap.Services
{
    public class AreaService : IAreaService
    {
        private readonly ApplicationDbContext _context;

        public AreaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAreaAsync(Area area)
        {
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAreaAsync(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area != null)
            {
                _context.Areas.Remove(area);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Area>> GetAllAreaAsync()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Area> GetAreaAsync(int id)
        {
            return await _context.Areas.FindAsync(id);
        }

        public async Task UpdateAreaAsync(Area area)
        {
            _context.Areas.Update(area);
            await _context.SaveChangesAsync();
        }
    }
}

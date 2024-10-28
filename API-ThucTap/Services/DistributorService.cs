using API_ThucTap.Data;
using API_ThucTap.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ThucTap.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly ApplicationDbContext _context;

        public DistributorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddDistributorAsync(Distributor distributor)
        {
            await _context.Distributors.AddAsync(distributor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDistributorAsync(int id)
        {
            var distributor = await _context.Distributors.FindAsync(id);
            if (distributor != null)
            {
                _context.Distributors.Remove(distributor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Distributor>> GetAllDistributorAsync()
        {
            return await _context.Distributors.ToListAsync();
        }

        public async Task<Distributor> GetDistributorAsync(int id)
        {
            return await _context.Distributors.FindAsync(id);
        }

        public async Task UpdateDistributorAsync(Distributor distributor)
        {
            _context.Distributors.Update(distributor);
            await _context.SaveChangesAsync();
        }
    }
}

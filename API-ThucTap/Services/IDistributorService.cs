using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface IDistributorService
    {
        Task<IEnumerable<Distributor>> GetAllDistributorAsync();
        Task<Distributor> GetDistributorAsync(int id);
        Task AddDistributorAsync(Distributor distributor);
        Task UpdateDistributorAsync(Distributor distributor);
        Task DeleteDistributorAsync(int id);
    }
}

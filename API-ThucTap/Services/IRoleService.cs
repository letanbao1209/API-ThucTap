using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoleAsync();
        Task<Role> GetRoleAsync(int id);
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
    }
}

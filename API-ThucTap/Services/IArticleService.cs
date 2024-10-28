using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllArticleAsync();
        Task<Article> GetArticleAsync(int id);
        Task AddArticleAsync(Article article);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(int id);
    }
}

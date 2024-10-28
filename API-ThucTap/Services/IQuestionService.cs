using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllQuestionAsync();
        Task<Question> GetQuestionAsync(int id);
        Task AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int id);
    }
}

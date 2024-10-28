using API_ThucTap.Models;
namespace API_ThucTap.Services
{
    public interface ISurveyService
    {
        Task<IEnumerable<Survey>> GetAllSurveyAsync();
        Task<Survey> GetSurveyAsync(int id);
        Task AddSurveyAsync(Survey survey);
        Task UpdateSurveyAsync(Survey survey);
        Task DeleteSurveyAsync(int id);
    }
}

using API_ThucTap.Data;
using API_ThucTap.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ThucTap.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddSurveyAsync(Survey survey)
        {
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSurveyAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Survey>> GetAllSurveyAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<Survey> GetSurveyAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }

        public async Task UpdateSurveyAsync(Survey survey)
        {
            _context.Surveys.Update(survey);
            await _context.SaveChangesAsync();
        }
    }
}

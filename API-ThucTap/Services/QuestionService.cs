using API_ThucTap.Data;
using API_ThucTap.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ThucTap.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;

        public QuestionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddQuestionAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Question>> GetAllQuestionAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }
    }
}

using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionAll()
        {
            var question = await _questionService.GetAllQuestionAsync();
            return Ok(question);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestionId(int id)
        {
            var question = await _questionService.GetQuestionAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> CreateUser(Question question)
        {
            await _questionService.AddQuestionAsync(question);
            return CreatedAtAction(nameof(GetQuestionAll), new { id = question.QuestionId }, question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            await _questionService.UpdateQuestionAsync(question);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return NoContent();
        }
    }
}

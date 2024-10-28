using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveyAll()
        {
            var survey = await _surveyService.GetAllSurveyAsync();
            return Ok(survey);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurveyId(int id)
        {
            var survey = await _surveyService.GetSurveyAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost]
        public async Task<ActionResult<Survey>> CreateSurvey(Survey survey)
        {
            await _surveyService.AddSurveyAsync(survey);
            return CreatedAtAction(nameof(GetSurveyAll), new { id = survey.SurveyId }, survey);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, Survey survey)
        {
            if (id != survey.SurveyId)
            {
                return BadRequest();
            }

            await _surveyService.UpdateSurveyAsync(survey);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _surveyService.DeleteSurveyAsync(id);
            return NoContent();
        }
    }
}

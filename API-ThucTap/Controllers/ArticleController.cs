using API_ThucTap.Models;
using API_ThucTap.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticleAll()
        {
            var article = await _articleService.GetAllArticleAsync();
            return Ok(article);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticleId(int id)
        {
            var article = await _articleService.GetArticleAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> CreateArticle(Article article)
        {
            await _articleService.AddArticleAsync(article);
            return CreatedAtAction(nameof(GetArticleAll), new { id = article.ArticleId }, article);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            await _articleService.UpdateArticleAsync(article);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteArticleAsync(id);
            return NoContent();
        }
    }
}

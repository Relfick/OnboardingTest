using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingTest.Models;

namespace OnboardingTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ApplicationContext _db;

    public ArticleController(ApplicationContext db)
    {
        _db = db;
    }

    // GET: api/Article
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
    {
        if (_db.Articles == null)
        {
            return NotFound();
        }
        return await _db.Articles.ToListAsync();
    }
    
    // GET: api/Article/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        if (_db.Articles == null)
            return NotFound();

        var article = await _db.Articles.FindAsync(id);

        if (article == null)
            return NotFound();

        return article;
    }

    // PUT: api/Article/5
    // [HttpPut("{tgArticleId}")]
    // public async Task<IActionResult> PutArticle(long tgArticleId, Article Article)
    // {
    //     if (tgArticleId != Article.Id)
    //     {
    //         return BadRequest();
    //     }
    //
    //     _db.Entry(Article).State = EntityState.Modified;
    //
    //     try
    //     {
    //         await _db.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!ArticleExists(tgArticleId))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }
    //
    //     return NoContent();
    // }
    //
    // [HttpPut("workmode/{tgArticleId}")]
    // public async Task<IActionResult> PutWorkMode(long tgArticleId, [FromBody] ArticleWorkMode workMode)
    // {
    //     var Article = await _db.Articles.FirstOrDefaultAsync(u => u.Id == tgArticleId);
    //     if (Article == null)
    //         return NotFound();
    //
    //     Article.WorkMode = workMode;
    //     try
    //     {
    //         await _db.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!ArticleExists(tgArticleId))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }
    //
    //     return NoContent();
    // }
    
    // POST: api/Article
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Article>> PostArticle(Article article)
    {
        if (_db.Articles == null)
        {
            return Problem("Entity set 'ApplicationContext.Articles'  is null.");
        }
        _db.Articles.Add(article);
        await _db.SaveChangesAsync();

        // return CreatedAtAction("GetArticle", new { id = Article.Id }, Article);
        return NoContent();
    }

    // DELETE: api/Article/5
    // [HttpDelete("{tgArticleId}")]
    // public async Task<IActionResult> DeleteArticle(long tgArticleId)
    // {
    //     if (_db.Articles == null)
    //     {
    //         return NotFound();
    //     }
    //     var Article = await _db.Articles.FindAsync(tgArticleId);
    //     if (Article == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     _db.Articles.Remove(Article);
    //     await _db.SaveChangesAsync();
    //
    //     return NoContent();
    // }

    private bool ArticleExists(long id)
    {
        return (_db.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
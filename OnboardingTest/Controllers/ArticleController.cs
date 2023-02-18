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
        
        var articles = await _db.Articles
            .Include(a => a.Category)
            .ToListAsync();

        return articles;
    }
    
    // GET: api/Article/5
    // [HttpGet("{id}")]
    // public async Task<ActionResult<Article>> GetArticle(int id)
    // {
    //     if (_db.Articles == null)
    //         return NotFound();
    //
    //     var article = _db.Articles
    //         .Include(a => a.Category).FirstOrDefault(a => a.Id == id);
    //
    //     if (article == null)
    //         return NotFound();
    //
    //     return article;
    // }
    
    // GET: api/Article/5
    [HttpGet("{d}")]
    public async Task<ActionResult<NWArticle>> GetArticle(int id)
    {
        if (_db.Articles == null)
            return NotFound();

        var article = _db.Articles
            .Include(a => a.Category).FirstOrDefault(a => a.Id == id);

        if (article == null)
            return NotFound();

        var nwArticle = new NWArticle
        {
            Id = article.Id,
            Text = article.Text,
            Title = article.Title,
            Category = article.Category
        };

        return nwArticle;
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

        article.CategoryId = article.Category.Id;
        article.Category = null;
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
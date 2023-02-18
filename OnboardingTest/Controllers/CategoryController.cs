using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingTest.Models;

namespace OnboardingTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ApplicationContext _db;

    public CategoryController(ApplicationContext db)
    {
        _db = db;
    }

    // GET: api/Category
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        if (_db.Categories == null)
        {
            return NotFound();
        }

        return await _db.Categories.ToListAsync();
    }

    // GET: api/Category/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        if (_db.Categories == null)
            return NotFound();

        var Category = await _db.Categories.FindAsync(id);

        if (Category == null)
            return NotFound();

        return Category;
    }
    
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
        if (_db.Categories == null)
        {
            return Problem("Entity set 'ApplicationContext.Categories'  is null.");
        }
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();

        // return CreatedAtAction("GetCategories", new { id = Category.Id }, Category);
        return NoContent();
    }
}
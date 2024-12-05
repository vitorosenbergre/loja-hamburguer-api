using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEFProject.Data;

namespace MyEFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _categoriesContext;

        public CategoriesController(AppDbContext context)
        {
            _categoriesContext = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            // Usando eager loading para carregar as entidades relacionadas (exemplo com "Products")
            var categories = await _categoriesContext.Categories
                .Include(c => c.Products) // Aqui estamos assumindo que há uma relação com a entidade Product
                .ToListAsync();

            return categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            // Usando eager loading para carregar os produtos relacionados a uma categoria específica
            var category = await _categoriesContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _categoriesContext.Categories.Add(category);
            await _categoriesContext.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _categoriesContext.Entry(category).State = EntityState.Modified;

            try
            {
                await _categoriesContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_categoriesContext.Categories.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoriesContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoriesContext.Categories.Remove(category);
            await _categoriesContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

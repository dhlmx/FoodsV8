using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodsV8.Data;
using FoodsV8.Models;

namespace FoodsV8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(CategoryDbContext context) : ControllerBase
    {
        private readonly CategoryDbContext _context = context;

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return this._context.Categories.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.Find(id);
            return category != null ? Ok(category) : NotFound();
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            var entity = _context.Categories.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = category.Name;

            _context.Update(entity);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Categories.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

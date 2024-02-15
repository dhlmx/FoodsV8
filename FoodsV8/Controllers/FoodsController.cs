using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodsV8.Data;
using FoodsV8.Models;

namespace FoodsV8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController(FoodDbContext context) : ControllerBase
    {
        private readonly FoodDbContext _context = context;

        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return _context.Foods.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var food = _context.Foods.Find(id);
            return food != null ? Ok(food) : NotFound();
        }

        [HttpPost]
        public IActionResult Post(Food food)
        {
            if (food == null) {
                return BadRequest();
            }

            _context.Foods.Add(food);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = food.FoodId }, food);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Food food)
        {
            if (id != food.FoodId)
            {
                return BadRequest();
            }

            var entity = _context.Foods.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Calories = food.Calories;
            entity.CategoryId = food.CategoryId;
            entity.Cholesterol = food.Cholesterol;
            entity.Fat = food.Fat;
            entity.Name = food.Name;
            entity.Quantity = food.Quantity;
            entity.Sodium = food.Sodium;
            entity.UnitId = food.UnitId;

            _context.Update(entity);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Foods.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

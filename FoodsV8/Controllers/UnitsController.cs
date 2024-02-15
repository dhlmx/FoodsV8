using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodsV8.Data;
using FoodsV8.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FoodsV8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController(UnitDbContext context) : ControllerBase
    {
        private readonly UnitDbContext _context = context;

        [HttpGet]
        public IEnumerable<Unit> Get()
        {
            return this._context.Units.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var unit = _context.Units.Find(id);
            return unit != null ? Ok(unit) : NotFound();
        }

        [HttpPost]
        public IActionResult Post(Unit unit)
        {
            if (unit == null)
            {
                return BadRequest();
            }

            _context.Units.Add(unit);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = unit.UnitId }, unit);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Unit unit)
        {
            if (id != unit.UnitId)
            {
                return BadRequest();
            }

            var entity = _context.Units.Find(id);

            if (entity == null) {
                return NotFound();
            }

            entity.Name = unit.Name;
            entity.Alias = unit.Alias;

            _context.Update(entity);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Units.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Units.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

using FoodsV8.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsV8.Data;

public class CategoryDbContext(DbContextOptions<CategoryDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
}

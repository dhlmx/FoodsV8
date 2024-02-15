using FoodsV8.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsV8.Data;

public class FoodDbContext(DbContextOptions<FoodDbContext> options) : DbContext(options)
{
    public DbSet<Food> Foods { get; set; } = null!;
}

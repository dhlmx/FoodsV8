using FoodsV8.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsV8.Data;

public class UnitDbContext(DbContextOptions<UnitDbContext> options) : DbContext(options)
{
    public DbSet<Unit> Units { get; set; } = null!;
}

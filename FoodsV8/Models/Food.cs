namespace FoodsV8.Models;

public class Food
{
    public int FoodId { get; set; } = 0;
    public int UnitId { get; set; } = 0;
    public int CategoryId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public double Quantity { get; set; } = 0;
    public double Calories { get; set; } = 0;
    public double Fat { get; set; } = 0;
    public double Cholesterol { get; set; } = 0;
    public double Sodium { get; set; } = 0;
}

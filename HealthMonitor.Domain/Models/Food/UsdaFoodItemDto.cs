namespace HealthMonitor.Domain.Models.Food;

public class UsdaFoodItemDto
{
    public int FdcId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? BrandName { get; set; }
    public string? DataType { get; set; }
    public double? Calories { get; set; }
    public double? Protein { get; set; }
    public double? Carbohydrates { get; set; }
    public double? Fat { get; set; }
}

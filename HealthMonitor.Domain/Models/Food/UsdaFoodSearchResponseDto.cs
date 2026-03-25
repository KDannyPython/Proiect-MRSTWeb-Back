namespace HealthMonitor.Domain.Models.Food;

public class UsdaFoodSearchResponseDto
{
    public int TotalHits { get; set; }
    public List<UsdaFoodItemDto> Foods { get; set; } = new();
}

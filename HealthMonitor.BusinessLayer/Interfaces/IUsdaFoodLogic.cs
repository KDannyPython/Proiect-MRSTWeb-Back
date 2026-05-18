using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IUsdaFoodLogic
{
    Task<UsdaFoodSearchResponseDto> SearchUsdaFoodAsync(string query);
    Task<UsdaFoodItemDto?> GetFoodByIdAsync(int fdcId);
}

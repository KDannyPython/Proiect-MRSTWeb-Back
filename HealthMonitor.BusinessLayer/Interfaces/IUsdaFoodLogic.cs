using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IUsdaFoodLogic
{
    Task<UsdaFoodSearchResponseDto> SearchUsdaFoodAsync(string query);

    //Task<ServiceResponse<List<FoodInfoDto>>> GetAllFoodsAsync();
    //Task<ServiceResponse<FoodInfoDto>> GetFoodByIdAsync(int id);
    //Task<ServiceResponse> CreateFoodAsync(FoodCreateDto food);
}

using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IFoodLogLogic
{
    Task<ServiceResponse> AddFoodLog(int userId, FoodLogDto foodLog);
    Task<ServiceResponse> UpdateFoodQuantity(int foodLogId, int quantityGrams);
    Task<ServiceResponse> DeleteFoodLog(int foodLogId);
    int GetTodayCalories(int userId);
}

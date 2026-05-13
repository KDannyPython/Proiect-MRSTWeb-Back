using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IFoodLogLogic
{
    Task<ServiceResponse> LogFoodAction(int userId, FoodLogDto foodLog);
    Task<ServiceResponse> UpdateFoodQuantityAction(int foodLogId, double quantityGrams);
    Task<ServiceResponse> DeleteFoodLogAction(int foodLogId);
}

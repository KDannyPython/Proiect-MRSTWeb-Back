using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IFoodLogic
{
    ServiceResponse CreateFood(FoodCreateDto food);
    ServiceResponse GetFoodById(int Id);
    ServiceResponse GetFoodByName(string Name);
    ServiceResponse GetFoodList();
    ServiceResponse DeleteFoodById(int Id);
    ServiceResponse UpdateFoodById(int Id, FoodUpdateDto food);
}

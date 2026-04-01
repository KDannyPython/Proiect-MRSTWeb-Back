using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IFoodLogic
{
    ServiceResponse CreateFood(FoodCreateDto food);
    ServiceResponse DeleteFoodById(int Id);
    ServiceResponse GetFoodById(int id);
    ServiceResponse GetFoodList();

}

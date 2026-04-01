using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Core;

public class FoodLogic : FoodActions, IFoodLogic
{
    public ServiceResponse CreateFood(FoodCreateDto food)
    {
        var result = CreateFoodAction(food);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Failed to create food item."
            };
        }
        return new ServiceResponse
        {
            IsSucces = true,
            Message = "Food created successfully."
        };
    }

    public ServiceResponse DeleteFoodById(int Id)
    {
        var result = DeleteFoodAction(Id);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Food item not found or failed to delete."
            };
        }
        return new ServiceResponse
        {
            IsSucces = true,
            Message = "Food deleted successfully."
        };
    }

    public ServiceResponse GetFoodById(int id)
    {
        var food = GetFoodByIdAction(id);
        if (food==null)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Food item not found."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Data = food
        };
    }

    public ServiceResponse GetFoodList()
    {
        var foodList = GetFoodListAction();

        return new ServiceResponse
        {
            IsSucces = true,
            Data = GetFoodListAction()
        };
    }
}

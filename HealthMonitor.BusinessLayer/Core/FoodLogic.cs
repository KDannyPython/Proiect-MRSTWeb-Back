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
                IsSuccess = false,
                Message = "Failed to create food item."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Food created successfully."
        };
    }

    public ServiceResponse GetFoodById(int Id)
    {
        var food = GetFoodByIdAction(Id);
        if (food==null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Food item not found."
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Data = food
        };
    }

    public ServiceResponse GetFoodByName(string Name)
    {
        var food = GetFoodByNameAction(Name);
        if (food == null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Food item not found with this name."
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Data = food
        };
    }

    public ServiceResponse GetFoodList()
    {
        var foodList = GetFoodListAction();

        return new ServiceResponse
        {
            IsSuccess = true,
            Data = GetFoodListAction()
        };
    }

    public ServiceResponse DeleteFoodById(int Id)
    {
        var result = DeleteFoodAction(Id);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Food item not found or failed to delete."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Food deleted successfully."
        };
    }

    public ServiceResponse UpdateFoodById(int Id, FoodUpdateDto food)
    {
        var result = UpdateFoodAction(Id, food);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Food item not found or failed to update."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Food updated successfully."
        };
    }
}

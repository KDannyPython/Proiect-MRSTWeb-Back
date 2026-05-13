using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Core;

public class FoodLogLogic : FoodLogActions, IFoodLogLogic
{
    public async  Task<ServiceResponse> LogFoodAction(FoodCreateDto food)
    {
        var result = await LogFoodAction(food);
        if (!result.IsSuccess)
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

    public async Task<ServiceResponse> UpdateFoodQuantity(int foodLogId, double quantityGrams)
    {
        var result = await UpdateFoodQuantityAction(foodLogId,quantityGrams);

        if (!result.IsSuccess)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = result.Message
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Food quantity updated successfully."
        };
    }

    public async Task<ServiceResponse> DeleteFoodLog(int foodLogId)
    {
        var result = await DeleteFoodLogAction(foodLogId);

        if (!result.IsSuccess)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = result.Message
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Food log deleted successfully."
        };
    }
}

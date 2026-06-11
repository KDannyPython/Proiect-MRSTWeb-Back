using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.BusinessLayer.Core;

public class FoodLogLogic : FoodLogActions, IFoodLogLogic
{
    public async  Task<ServiceResponse> AddFoodLog(int userId, FoodLogDto food)
    {
        var result = await LogFoodAction(userId, food);
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
            Message = "Food created successfully."
        };
    }

    public async Task<ServiceResponse> UpdateFoodQuantity(int foodLogId, int userId, int quantityGrams)
    {
        var result = await UpdateFoodQuantityAction(foodLogId, userId, quantityGrams);

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

    public async Task<ServiceResponse> DeleteFoodLog(int foodLogId, int userId)
    {
        var result = await DeleteFoodLogAction(foodLogId, userId);

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

    public int GetTodayCalories(int userId)
    {
        return GetTodayCaloriesAction(userId);
    }

    public ServiceResponse ResetFoodLogs(int userId)
    {
        return ResetFoodLogsAction(userId);
    }

    public List<FoodLogResponseDto> GetTodayFoodLogs(int userId)
    {
        return GetTodayFoodLogsAction(userId);
    }
}

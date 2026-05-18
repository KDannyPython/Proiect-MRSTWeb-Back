using HealthMonitor.BusinessLayer.Core;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.BusinessLayer.Structure;

public class FoodLogActions
{
    private readonly AppDbContext _context;
    private readonly UsdaFoodLogic _usdaFoodLogic;
    public FoodLogActions()
    {
        _context = new AppDbContext();

        _usdaFoodLogic = new UsdaFoodLogic(new HttpClient());
    }

    public async Task<ServiceResponse> LogFoodAction(int userId, FoodLogDto foodLog)
    {
        try
        {
            var foodEntity = await _context.Foods
                .FirstOrDefaultAsync(x => x.FdcId == foodLog.FdcId);

            if (foodEntity == null)
            {
                var usdaFood = await _usdaFoodLogic.GetFoodByIdAsync(foodLog.FdcId);

                if (usdaFood == null)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "Food not found in USDA."
                    };
                }

                foodEntity = new FoodEntity
                {
                    FdcId = usdaFood.FdcId,
                    Name = usdaFood.Description,
                    Calories = (float)(usdaFood.Calories ?? 0),
                    Protein = (float)(usdaFood.Protein ?? 0),
                    Carbohydrates = (float)(usdaFood.Carbohydrates ?? 0),
                    Fat = (float)(usdaFood.Fat ?? 0)
                };

                await _context.Foods.AddAsync(foodEntity);
                await _context.SaveChangesAsync();
            }

            var foodLogEntity = new FoodLogEntity
            {
                UserId = userId,

                FoodId = foodEntity.Id,

                QuantityGrams = foodLog.QuantityGrams,

                LoggedAt = DateTime.UtcNow
            };

            await _context.FoodLogs.AddAsync(foodLogEntity);

            await _context.SaveChangesAsync();

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Food logged successfully."
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
        }
    }

    public async Task<ServiceResponse> UpdateFoodQuantityAction(int foodLogId, int quantityGrams)
    {
        try
        {
            var foodLog = await _context.FoodLogs.FirstOrDefaultAsync(x => x.Id == foodLogId);

            if (foodLog == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Food log not found."
                };
            }

            foodLog.QuantityGrams = quantityGrams;

            await _context.SaveChangesAsync();

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Food quantity updated successfully."
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ServiceResponse> DeleteFoodLogAction(int foodLogId)
    {
        try
        {
            var foodLog = await _context.FoodLogs
                .FirstOrDefaultAsync(x => x.Id == foodLogId);

            if (foodLog == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Food log not found."
                };
            }

            _context.FoodLogs.Remove(foodLog);

            await _context.SaveChangesAsync();

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Food log deleted successfully."
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    public int GetTodayCaloriesAction(int userId)
    {
        var today = DateTime.UtcNow.Date;

        var todayLogs = _context.FoodLogs
            .Include(x => x.Food)
            .Where(x =>
                x.UserId == userId &&
                x.LoggedAt.Date == today)
            .ToList();

        if (!todayLogs.Any())
        {
            return 0;
        }

        int totalCalories = (int)Math.Round(todayLogs.Sum(x =>
            (x.QuantityGrams * x.Food.Calories) / 100
        ));

        return totalCalories;
    }
}
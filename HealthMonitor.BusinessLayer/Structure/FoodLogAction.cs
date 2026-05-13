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

    public FoodLogActions(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse> LogFoodAction(int userId, FoodLogDto foodLog)
    {
        try
        {
            // cautam food local dupa FdcId
            var foodEntity = await _context.Foods
                .FirstOrDefaultAsync(x => x.FdcId == foodLog.FdcId);

            // daca nu exista local -> luam din USDA
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

                // cream food local
                foodEntity = new FoodEntity
                {
                    FdcId = usdaFood.FdcId,
                    Name = usdaFood.Description,
                    Calories = (float)usdaFood.Calories,
                    Protein = (float)usdaFood.Protein,
                    Carbohydrates = (float)usdaFood.Carbohydrates,
                    Fat = (float)usdaFood.Fat
                };

                await _context.Foods.AddAsync(foodEntity);

                await _context.SaveChangesAsync();
            }

            // cream log
            var foodLogEntity = new FoodLogEntity
            {
                UserId = userId,

                // ID local
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
                Message = ex.InnerException?.Message ?? ex.Message
            };
        }
    }

    public async Task<ServiceResponse> UpdateFoodQuantityAction(int foodLogId, double quantityGrams)
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
}
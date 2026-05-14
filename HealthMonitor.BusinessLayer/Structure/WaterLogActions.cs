using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Water;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Water;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.BusinessLayer.Structure;

public class WaterLogActions
{
    private readonly AppDbContext _context;

    public WaterLogActions()
    {
        _context = new AppDbContext();
    }

    public ServiceResponse AddWaterAction(int userId, WaterLogDto water)
    {
        try
        {
            var today = DateTime.UtcNow.Date;
            var waterLog = _context.WaterLogs
                .FirstOrDefault(x =>
                    x.UserId == userId &&
                    x.LoggedAt == today);

            if (waterLog == null)
            {
                waterLog = new WaterLogEntity
                {
                    UserId = userId,
                    AmountMl = water.AmountMl,
                    LoggedAt = today
                };

                _context.WaterLogs.Add(waterLog);
            }
            else
            {
                waterLog.AmountMl += water.AmountMl;
            }
            _context.SaveChanges();

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Water intake logged successfully."
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = $"Failed to log water intake: {ex.Message}"
            };
        }
    }

    public ServiceResponse RemoveWaterAction(int userId, WaterLogDto water)
    {
        try
        {
            var today = DateTime.UtcNow.Date;

            var waterLog = _context.WaterLogs
                .FirstOrDefault(x =>
                    x.UserId == userId &&
                    x.LoggedAt == today);

            if (waterLog == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "No water log for today."
                };
            }

            waterLog.AmountMl -= water.AmountMl;

            if (waterLog.AmountMl < 0) waterLog.AmountMl = 0;

            _context.SaveChanges();

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Water intake removed successfully."
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = $"Failed to remove water intake: {ex.Message}"
            };
        }
    }

    public int GetTodayWaterAction(int userId)
    {
        var today = DateTime.UtcNow.Date;

        var waterLog = _context.WaterLogs
            .FirstOrDefault(x =>
                x.UserId == userId &&
                x.LoggedAt == today);

        if (waterLog == null)
        {
            return 0;
        }

        return waterLog.AmountMl;
    }
}
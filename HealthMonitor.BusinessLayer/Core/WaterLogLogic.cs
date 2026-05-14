using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Water;

namespace HealthMonitor.BusinessLayer.Core;

public class WaterLogLogic : WaterLogActions, IWaterLogLogic
{
    public ServiceResponse AddWater(int userId, WaterLogDto water)
    {
        var result = AddWaterAction(userId, water);
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
            Message = "Water log added successfully."
        };
    }

    public ServiceResponse RemoveWater(int useId, WaterLogDto water)
    {
        var result = RemoveWaterAction(useId, water);
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
            Message = "Water log removed successfully."
        };
    }

    public int GetTodayWater(int userId)
    {
        return GetTodayWaterAction(userId);
    }
}

using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Water;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IWaterLogLogic
{
    ServiceResponse AddWater(int userId, WaterLogDto water);

    ServiceResponse RemoveWater(int userId, WaterLogDto water);

    int GetTodayWater(int userId);
}

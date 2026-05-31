using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Core
{
    public class WeightLogLogic : WeightLogActions, IWeightLogLogic
    {
        public Task<ServiceResponse> LogWeight(int userId, WeightLogDto dto)
        {
            return LogWeightAction(userId, dto);
        }

        public Task<List<WeightLogResponseDto>> GetWeightHistory(int userId, int? limit)
        {
            return GetWeightHistoryAction(userId, limit);
        }
    }
}

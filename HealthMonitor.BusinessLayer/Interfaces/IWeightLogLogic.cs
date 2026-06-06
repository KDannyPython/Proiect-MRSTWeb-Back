using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IWeightLogLogic
    {
        Task<ServiceResponse> LogWeight(int userId, WeightLogDto dto);
        Task<List<WeightLogResponseDto>> GetWeightHistory(int userId, int? limit);
        Task<ServiceResponse> DeleteWeightLog(int userId, int logId);
    }
}

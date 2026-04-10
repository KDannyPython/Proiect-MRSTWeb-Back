using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.DailyRecord;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IDailyRecordLogic
{
    ServiceResponse CreateDailyRecord(DailyRecordCreateDto dailyRecordDto);
    ServiceResponse GetDailyRecordById(int id);
    ServiceResponse GetDailyRecordList();
    ServiceResponse UpdateDailyRecord(int id, DailyRecordCreateDto dailyRecordDto);
    ServiceResponse DeleteDailyRecord(int id);
}
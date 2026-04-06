using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.DailyRecord;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IDailyRecordLogic
{
    ServiceResponse CreateDailyRecord(DailyRecordCreateDto dailyRecordDto); //create
    ServiceResponse GetDailyRecordById(int id); //read
    ServiceResponse GetDailyRecordList(); //read
    ServiceResponse UpdateDailyRecord(int id, DailyRecordCreateDto dailyRecordDto); //update
    ServiceResponse DeleteDailyRecord(int id); //delete
}
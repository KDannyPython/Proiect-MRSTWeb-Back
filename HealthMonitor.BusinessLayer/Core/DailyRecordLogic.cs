using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.DailyRecord;

namespace HealthMonitor.BusinessLayer.Core;

public class DailyRecordLogic : DailyRecordActions, IDailyRecordLogic
{
    public ServiceResponse CreateDailyRecord(DailyRecordCreateDto dailyRecordDto)
    {
        var result = CreateDailyRecordAction(dailyRecordDto);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "A eșuat salvarea recordului zilnic."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Message = "Recordul zilnic a fost salvat cu succes în Postgres!"
        };
    }

    public ServiceResponse GetDailyRecordById(int id)
    {
        var dailyRecord = GetDailyRecordByIdAction(id);
        if (dailyRecord == null)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Recordul zilnic nu a putut fi găsit (Id invalid)."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Data = dailyRecord
        };
    }

    public ServiceResponse GetDailyRecordList()
    {
        return new ServiceResponse
        {
            IsSucces = true,
            Data = GetDailyRecordListAction()
        };
    }
}
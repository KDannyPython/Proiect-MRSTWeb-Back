using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.DailyRecord;

namespace HealthMonitor.BusinessLayer.Core;

public class DailyRecordLogic : DailyRecordActions, IDailyRecordLogic
{
    // CREATE (C)
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

    // READ BY ID (R)
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

    // READ ALL (R)
    public ServiceResponse GetDailyRecordList()
    {
        return new ServiceResponse
        {
            IsSucces = true,
            Data = GetDailyRecordListAction()
        };
    }

    //UPDATE (U)
    public ServiceResponse UpdateDailyRecord(int id, DailyRecordCreateDto dto)
    {
        var success = UpdateDailyRecordAction(id, dto);
        if (!success)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Actualizarea recordului zilnic a eșuat."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Message = "Recordul zilnic a fost actualizat cu succes!"
        };
    }

    // DELETE (D)
    public ServiceResponse DeleteDailyRecord(int id)
    {
        var success = DeleteDailyRecordAction(id);
        if (!success)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Ștergerea recordului zilnic a eșuat."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Message = "Recordul zilnic a fost șters cu succes!"
        };
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.DailyRecord;
using HealthMonitor.Domain.Models.DailyRecord;

namespace HealthMonitor.BusinessLayer.Structure;

public class DailyRecordActions
{
    private readonly AppDbContext _context;

    public DailyRecordActions()
    {
        _context = new AppDbContext();
    }

    // CREATE (C)
    public bool CreateDailyRecordAction(DailyRecordCreateDto dailyRecordDto)
    {
        var currentUserId = "mock-user-123"; //o sa dam replace dupa ce avem JWT

        var dailyRecordEntity = new DailyRecord
        {
            UserId = currentUserId,
            Date = dailyRecordDto.Date,
            CaloriesConsumed = dailyRecordDto.CaloriesConsumed,
            CaloriesGoal = dailyRecordDto.CaloriesGoal,
            Weight = dailyRecordDto.Weight,
            WaterConsumedMl = dailyRecordDto.WaterConsumedMl,
            WaterGoalMl = dailyRecordDto.WaterGoalMl
        };

        try
        {
            _context.Add(dailyRecordEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // READ BY ID (R)
    public DailyRecordInfoDto? GetDailyRecordByIdAction(int id)
    {
        var dailyRecordEntity = _context.DailyRecords.Find(id);
        if (dailyRecordEntity == null)
        {
            return null;
        }

        return new DailyRecordInfoDto
        {
            Id = dailyRecordEntity.Id,
            UserId = dailyRecordEntity.UserId,
            Date = dailyRecordEntity.Date,
            CaloriesConsumed = dailyRecordEntity.CaloriesConsumed,
            CaloriesGoal = dailyRecordEntity.CaloriesGoal,
            Weight = dailyRecordEntity.Weight,
            WaterConsumedMl = dailyRecordEntity.WaterConsumedMl,
            WaterGoalMl = dailyRecordEntity.WaterGoalMl
        };
    }

    // READ ALL (R)
    public List<DailyRecordInfoDto> GetDailyRecordListAction()
    {
        return _context.DailyRecords.Select(d => new DailyRecordInfoDto
        {
            Id = d.Id,
            UserId = d.UserId,
            Date = d.Date,
            CaloriesConsumed = d.CaloriesConsumed,
            CaloriesGoal = d.CaloriesGoal,
            Weight = d.Weight,
            WaterConsumedMl = d.WaterConsumedMl,
            WaterGoalMl = d.WaterGoalMl
        }).ToList();
    }

    // UPDATE (U)
    public bool UpdateDailyRecordAction(int id, DailyRecordCreateDto dto)
    {
        var entity = _context.DailyRecords.Find(id);
        if (entity == null) return false;

        entity.Date = dto.Date;
        entity.CaloriesConsumed = dto.CaloriesConsumed;
        entity.CaloriesGoal = dto.CaloriesGoal;
        entity.Weight = dto.Weight;
        entity.WaterConsumedMl = dto.WaterConsumedMl;
        entity.WaterGoalMl = dto.WaterGoalMl;

        try { _context.SaveChanges(); return true; }
        catch (Exception) { return false; }
    }

    // DELETE (D)
    public bool DeleteDailyRecordAction(int id)
    {
        var entity = _context.DailyRecords.Find(id);
        if (entity == null) return false;

        try 
        {
            _context.DailyRecords.Remove(entity);
            _context.SaveChanges(); 
            return true;
        }
        catch (Exception) 
        {
            return false;
        }
    }

}
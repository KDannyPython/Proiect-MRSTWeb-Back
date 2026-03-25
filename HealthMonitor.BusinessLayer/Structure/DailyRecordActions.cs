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

    public bool CreateDailyRecordAction(DailyRecordCreateDto dailyRecordDto)
    {
        var dailyRecordEntity = new DailyRecord
        {
            UserId = dailyRecordDto.UserId,
            Date = dailyRecordDto.Date,
            CaloriesConsumed = dailyRecordDto.CaloriesConsumed,
            CaloriesBurned = dailyRecordDto.CaloriesBurned,
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
            CaloriesBurned = dailyRecordEntity.CaloriesBurned,
            CaloriesGoal = dailyRecordEntity.CaloriesGoal,
            Weight = dailyRecordEntity.Weight,
            WaterConsumedMl = dailyRecordEntity.WaterConsumedMl,
            WaterGoalMl = dailyRecordEntity.WaterGoalMl
        };
    }

    public List<DailyRecordInfoDto> GetDailyRecordListAction()
    {
        return _context.DailyRecords.Select(d => new DailyRecordInfoDto
        {
            Id = d.Id,
            UserId = d.UserId,
            Date = d.Date,
            CaloriesConsumed = d.CaloriesConsumed,
            CaloriesBurned = d.CaloriesBurned,
            CaloriesGoal = d.CaloriesGoal,
            Weight = d.Weight,
            WaterConsumedMl = d.WaterConsumedMl,
            WaterGoalMl = d.WaterGoalMl
        }).ToList();
    }
}
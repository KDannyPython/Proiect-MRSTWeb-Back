using System;
using System.Collections.Generic;
using System.Linq;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Structure;

public class WorkoutActions
{
    private readonly AppDbContext _context;

    public WorkoutActions()
    {
        _context = new AppDbContext();
    }
    public bool CreateWorkoutAction(WorkoutCreateDto workoutDto)
    {
        var workoutEntity = new Workout
        {
            UserId = workoutDto.UserId,
            Date = workoutDto.Date,
            Duration = workoutDto.Duration,
            Type = workoutDto.Type,
            Label = workoutDto.Label,
            CaloriesBurned = workoutDto.CaloriesBurned
        };

        try
        {
            _context.Add(workoutEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public WorkoutInfoDto? GetWorkoutByIdAction(int id)
    {
        var workoutEntity = _context.Workouts.Find(id);
        if (workoutEntity == null)
        {
            return null;
        }

        return new WorkoutInfoDto
        {
            Id = workoutEntity.Id,
            UserId = workoutEntity.UserId,
            Date = workoutEntity.Date,
            Duration = workoutEntity.Duration,
            Type = workoutEntity.Type,
            Label = workoutEntity.Label,
            CaloriesBurned = workoutEntity.CaloriesBurned
        };
    }

    public List<WorkoutInfoDto> GetWorkoutListAction()
    {
        return _context.Workouts.Select(w => new WorkoutInfoDto
        {
            Id = w.Id,
            UserId = w.UserId,
            Date = w.Date,
            Duration = w.Duration,
            Type = w.Type,
            Label = w.Label,
            CaloriesBurned = w.CaloriesBurned
        }).ToList();
    }
}

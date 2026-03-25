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

    //CREATE (C)
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

    //READ by id (R)
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
    //READ ALL (R)
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

    //UPDATE (U)
        public bool UpdateWorkoutAction(int id, WorkoutCreateDto workoutDto)
    {
        var workoutEntity = _context.Workouts.Find(id); // Cautam antrenamentul vechi
        if (workoutEntity == null) return false;

        // Suprascriem cu datele noi
        workoutEntity.Date = workoutDto.Date;
        workoutEntity.Duration = workoutDto.Duration;
        workoutEntity.Type = workoutDto.Type;
        workoutEntity.Label = workoutDto.Label;
        workoutEntity.CaloriesBurned = workoutDto.CaloriesBurned;

        try { _context.SaveChanges(); return true; }
        catch (Exception) { return false; }
    }

    //DELETE (D)
    public bool DeleteWorkoutAction(int id)
    {
        var workoutEntity = _context.Workouts.Find(id); // Gasim id-ul
        if (workoutEntity == null) return false;

        try { _context.Workouts.Remove(workoutEntity); _context.SaveChanges(); return true; }
        catch (Exception) { return false; }
    }

}

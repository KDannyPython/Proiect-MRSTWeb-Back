using System;
using System.Collections.Generic;
using System.Linq;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Entities.WorkoutExercise;
using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Models.Workout;
using HealthMonitor.Domain.Models.WorkoutExercise;
using Microsoft.EntityFrameworkCore; //pt .Include()

namespace HealthMonitor.BusinessLayer.Structure;

public class WorkoutActions
{
    private readonly AppDbContext _context;

    public WorkoutActions()
    {
        _context = new AppDbContext();
    }

    //CREATE (C)
    public bool CreateWorkoutAction(WorkoutCreateDto workoutDto, int userId)
    {
        var currentUserId = userId;

        var workoutEntity = new Workout
        {
            UserId = currentUserId,
            Date = workoutDto.Date,
            Duration = workoutDto.Duration,
            Type = workoutDto.Type,
            Label = workoutDto.Label,

            WorkoutExercises = workoutDto.WorkoutExercises.Select(dto => new WorkoutExercise
            {
                ExerciseId = dto.ExerciseId,
                Sets = dto.Sets,
                Reps = dto.Reps,
                Weight = dto.Weight
            }).ToList()
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
        var workoutEntity = _context.Workouts
        .Include(w => w.WorkoutExercises)
        .ThenInclude(we => we.Exercise)
        .FirstOrDefault(w => w.Id == id);
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

            WorkoutExercises = workoutEntity.WorkoutExercises.Select(we => new WorkoutExerciseInfoDto
            {
                ExerciseId = we.ExerciseId,
                ExerciseName = we.Exercise.Name,
                PrimaryMuscleGroup = we.Exercise.PrimaryMuscleGroup,
                SecondaryMuscleGroup = we.Exercise.SecondaryMuscleGroup,
                Difficulty = we.Exercise.Difficulty,
                FatigueCost = we.Exercise.FatigueCost,
                Sets = we.Sets,
                Reps = we.Reps,
                Weight = we.Weight,
            }).ToList()
            
        };
    }
    //READ ALL (R)
    public List<WorkoutInfoDto> GetWorkoutListAction(int userId)
    {
        return _context.Workouts
        .Where(w => w.UserId == userId)
        .Include(w => w.WorkoutExercises)
        .ThenInclude(we => we.Exercise)
        .Select(w => new WorkoutInfoDto
        {
            Id = w.Id,
            UserId = w.UserId,
            Date = w.Date,
            Duration = w.Duration,
            Type = w.Type,
            Label = w.Label,

            WorkoutExercises = w.WorkoutExercises.Select(we => new WorkoutExerciseInfoDto
            {
                ExerciseId = we.ExerciseId,
                ExerciseName = we.Exercise.Name,
                PrimaryMuscleGroup = we.Exercise.PrimaryMuscleGroup,
                SecondaryMuscleGroup = we.Exercise.SecondaryMuscleGroup,
                Difficulty = we.Exercise.Difficulty,
                FatigueCost = we.Exercise.FatigueCost,
                Sets = we.Sets,
                Reps = we.Reps,
                Weight = we.Weight,
            }).ToList()
        }).ToList();
    }

    //UPDATE (U)
        public bool UpdateWorkoutAction(int id, WorkoutCreateDto workoutDto, int userId)
    {
        var workoutEntity = _context.Workouts
        .Include(w => w.WorkoutExercises)
        .FirstOrDefault(w => w.Id == id);

        if (workoutEntity == null || workoutEntity.UserId != userId) 
        {
            return false;
        }
        
        workoutEntity.Date = workoutDto.Date;
        workoutEntity.Duration = workoutDto.Duration;
        workoutEntity.Type = workoutDto.Type;
        workoutEntity.Label = workoutDto.Label;

        _context.WorkoutExercises.RemoveRange(workoutEntity.WorkoutExercises);

        var newLinkItems = workoutDto.WorkoutExercises.Select(dto => new WorkoutExercise
        {
            WorkoutId = workoutEntity.Id,
            ExerciseId = dto.ExerciseId,
            Sets = dto.Sets,
            Reps = dto.Reps,
            Weight = dto.Weight
        }).ToList();

        _context.WorkoutExercises.AddRange(newLinkItems);

        try { 
            _context.SaveChanges(); 
            return true; 
        }
        catch (Exception) { 
            return false; 
        }
    }

    //DELETE (D)
    public bool DeleteWorkoutAction(int id)
    {
        var workoutEntity = _context.Workouts.Find(id);
        if (workoutEntity == null) {
            return false;
        }

        try { 
            _context.Workouts.Remove(workoutEntity); 
            _context.SaveChanges(); 
            return true; 
        }
        catch (Exception) { 
            return false; 
        }
    }

}

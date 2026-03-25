using System;
using System.Collections.Generic;
using System.Linq;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Models.Exercise;

namespace HealthMonitor.BusinessLayer.Structure;

public class ExerciseActions
{
    private readonly AppDbContext _context;

    public ExerciseActions()
    {
        _context = new AppDbContext();
    }

    //CREATE (C)
    public bool CreateExerciseAction(ExerciseCreateDto exerciseDto)
    {
        var exerciseEntity = new Exercise
        {
            Name = exerciseDto.Name,
            Sets = exerciseDto.Sets,
            Reps = exerciseDto.Reps,
            Weight = exerciseDto.Weight
        };

        try
        {
            _context.Add(exerciseEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    //READ BY ID (R)
    public ExerciseInfoDto? GetExerciseByIdAction(int id)
    {
        var exerciseEntity = _context.Exercises.Find(id);
        if (exerciseEntity == null)
        {
            return null;
        }

        return new ExerciseInfoDto
        {
            Id = exerciseEntity.Id,
            WorkoutId = exerciseEntity.WorkoutId,
            Name = exerciseEntity.Name,
            Sets = exerciseEntity.Sets,
            Reps = exerciseEntity.Reps,
            Weight = exerciseEntity.Weight
        };
    }

    //READ ALL (R)
    public List<ExerciseInfoDto> GetExerciseListAction()
    {
        return _context.Exercises.Select(e => new ExerciseInfoDto
        {
            Id = e.Id,
            WorkoutId = e.WorkoutId,
            Name = e.Name,
            Sets = e.Sets,
            Reps = e.Reps,
            Weight = e.Weight
        }).ToList();
    }

    // UPDATE (U)
    public bool UpdateExerciseAction(int id, ExerciseCreateDto exerciseDto)
    {
        var exerciseEntity = _context.Exercises.Find(id);
        if (exerciseEntity == null) return false;

        exerciseEntity.Name = exerciseDto.Name;
        exerciseEntity.Sets = exerciseDto.Sets;
        exerciseEntity.Reps = exerciseDto.Reps;
        exerciseEntity.Weight = exerciseDto.Weight;

        try 
        {
            _context.SaveChanges(); 
            return true;
        }
        catch (Exception) 
        {
            return false;
        }
    }

    // DELETE (D)
    public bool DeleteExerciseAction(int id)
    {
        var exerciseEntity = _context.Exercises.Find(id);
        if (exerciseEntity == null) return false;

        try 
        {
            _context.Exercises.Remove(exerciseEntity);
            _context.SaveChanges(); 
            return true;
        }
        catch (Exception) 
        {
            return false;
        }
    }

}
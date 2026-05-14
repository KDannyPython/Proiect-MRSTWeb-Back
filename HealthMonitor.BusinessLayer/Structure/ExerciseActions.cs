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
            PrimaryMuscleGroup = exerciseDto.PrimaryMuscleGroup,
            SecondaryMuscleGroup = exerciseDto.SecondaryMuscleGroup,
            Difficulty = exerciseDto.Difficulty,
            FatigueCost = exerciseDto.FatigueCost,
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
            Name = exerciseEntity.Name,
            PrimaryMuscleGroup = exerciseEntity.PrimaryMuscleGroup,
            SecondaryMuscleGroup = exerciseEntity.SecondaryMuscleGroup,
            Difficulty = exerciseEntity.Difficulty,
            FatigueCost = exerciseEntity.FatigueCost,
        };
    }

    //READ ALL (R)
    public List<ExerciseInfoDto> GetExerciseListAction()
    {
        return _context.Exercises.Select(e => new ExerciseInfoDto
        {
            Id = e.Id,
            Name = e.Name,
            PrimaryMuscleGroup = e.PrimaryMuscleGroup,
            SecondaryMuscleGroup = e.SecondaryMuscleGroup,
            Difficulty = e.Difficulty,
            FatigueCost = e.FatigueCost,
        }).ToList();
    }

    // UPDATE (U)
    public bool UpdateExerciseAction(int id, ExerciseCreateDto exerciseDto)
    {
        var exerciseEntity = _context.Exercises.Find(id);
        if (exerciseEntity == null) return false;

        exerciseEntity.Name = exerciseDto.Name;
        exerciseEntity.PrimaryMuscleGroup = exerciseDto.PrimaryMuscleGroup;
        exerciseEntity.SecondaryMuscleGroup = exerciseDto.SecondaryMuscleGroup;
        exerciseEntity.Difficulty = exerciseDto.Difficulty;
        exerciseEntity.FatigueCost = exerciseDto.FatigueCost;

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
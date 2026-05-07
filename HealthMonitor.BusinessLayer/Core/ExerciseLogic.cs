using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Exercise;

namespace HealthMonitor.BusinessLayer.Core;

public class ExerciseLogic : ExerciseActions, IExerciseLogic
{
    // CREATE (C)
    public ServiceResponse CreateExercise(ExerciseCreateDto exerciseDto)
    {
        var result = CreateExerciseAction(exerciseDto);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "A eșuat salvarea exercițiului."
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Exercițiul a fost salvat cu succes în Postgres!"
        };
    }

    // READ BY ID (R)
    public ServiceResponse GetExerciseById(int id)
    {
        var exercise = GetExerciseByIdAction(id);
        if (exercise == null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Exercițiul nu a putut fi găsit (Id invalid)."
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Data = exercise
        };
    }

    // READ ALL (R)
    public ServiceResponse GetExerciseList()
    {
        return new ServiceResponse
        {
            IsSuccess = true,
            Data = GetExerciseListAction()
        };
    }

    // UPDATE (U)
    public ServiceResponse UpdateExercise(int id, ExerciseCreateDto exerciseDto)
    {
        var result = UpdateExerciseAction(id, exerciseDto);
        if (result == false)
        {
            return new ServiceResponse 
            {
                IsSuccess = false, 
                Message = "Eșec la modificare (Id invalid?)."
            };
        }

        return new ServiceResponse 
        {
            IsSuccess = true, 
            Message = "Exercițiul a fost modificat!"
        };
    }

    // DELETE (D)
    public ServiceResponse DeleteExercise(int id)
    {
        var result = DeleteExerciseAction(id);
        if (result == false)
        {
            return new ServiceResponse 
            {
                IsSuccess = false, 
                Message = "Eșec la ștergere (Id invalid?)."
            };
        }

        return new ServiceResponse 
        {
            IsSuccess = true, 
            Message = "Exercițiul a fost șters permanent!"
        };
    }

}
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Exercise;

namespace HealthMonitor.BusinessLayer.Core;

public class ExerciseLogic : ExerciseActions, IExerciseLogic
{
    public ServiceResponse CreateExercise(ExerciseCreateDto exerciseDto)
    {
        var result = CreateExerciseAction(exerciseDto);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "A eșuat salvarea exercițiului."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Message = "Exercițiul a fost salvat cu succes în Postgres!"
        };
    }

    public ServiceResponse GetExerciseById(int id)
    {
        var exercise = GetExerciseByIdAction(id);
        if (exercise == null)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Exercițiul nu a putut fi găsit (Id invalid)."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Data = exercise
        };
    }

    public ServiceResponse GetExerciseList()
    {
        return new ServiceResponse
        {
            IsSucces = true,
            Data = GetExerciseListAction()
        };
    }
}
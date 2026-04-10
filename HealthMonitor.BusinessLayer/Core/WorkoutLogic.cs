using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Core;

public class WorkoutLogic : WorkoutActions, IWorkoutLogic
{
    //CREATE (C)
    public ServiceResponse CreateWorkout(WorkoutCreateDto workout)
    {
        var result = CreateWorkoutAction(workout);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSucces = false, 
                Message = "A eșuat salvarea antrenamentului."
            };
        }
        
        return new ServiceResponse
        {
            IsSucces = true,
            Message = "Antrenamentul a fost salvat cu succes în Postgres!"
        };
    }
    //READ by id (R)
    public ServiceResponse GetWorkoutById(int id)
    {
        var workout = GetWorkoutByIdAction(id);
        if (workout == null)
        {
            return new ServiceResponse
            {
                IsSucces = false,
                Message = "Antrenamentul nu a putut fi găsit (Id invalid)."
            };
        }

        return new ServiceResponse
        {
            IsSucces = true,
            Data = workout
        };
    }

    //READ ALL (R)  
    public ServiceResponse GetWorkoutList()
    {
        return new ServiceResponse
        {
            IsSucces = true,
            Data = GetWorkoutListAction()
        };
    }

    //UPDATE (U)
    public ServiceResponse UpdateWorkout(int id, WorkoutCreateDto workout)
    {
        var result = UpdateWorkoutAction(id, workout);
        if (result == false)
        {
            return new ServiceResponse 
            {
                IsSucces = false, 
                Message = "Eșec la modificare (Id invalid?)."
            };
        }

        return new ServiceResponse 
        {
            IsSucces = true, 
            Message = "Antrenamentul a fost modificat!"
        };
    }

    //DELETE (D)
    public ServiceResponse DeleteWorkout(int id)
    {
        var workout = GetWorkoutByIdAction(id);
        if (workout == null)
        {
            return new ServiceResponse 
            {
                IsSucces = false, 
                Message = "Antrenamentul nu a putut fi găsit (Id invalid)."
            };
        }

        var result = DeleteWorkoutAction(id);
        if (result == false)
        {
            return new ServiceResponse 
            {
                IsSucces = false, 
                Message = "Eșec la ștergere (Id invalid?)."
            };
        }

        return new ServiceResponse 
        {
            IsSucces = true, 
            Message = "Antrenamentul a fost șters permanent!"
        };
    }

}

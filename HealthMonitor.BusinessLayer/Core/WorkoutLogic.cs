using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Core;

public class WorkoutLogic : WorkoutActions, IWorkoutLogic
{
    //CREATE (C)
    public ServiceResponse CreateWorkout(WorkoutCreateDto workoutDto, int userId)
    {
        var result = CreateWorkoutAction(workoutDto, userId);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false, 
                Message = "A eșuat salvarea antrenamentului."
            };
        }
        
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Antrenamentul a fost salvat cu succes în Postgres!"
        };
    }
    
    //READ BY ID (R)
    public ServiceResponse GetWorkoutById(int id)
    {
        var workout = GetWorkoutByIdAction(id);
        if (workout == null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Antrenamentul nu a putut fi găsit (Id invalid)."
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Data = workout
        };
    }

    //READ ALL (R)  
    public ServiceResponse GetWorkoutList(int userId)
    {
        return new ServiceResponse
        {
            IsSuccess = true,
            Data = GetWorkoutListAction(userId)
        };
    }

    //UPDATE (U)
    public ServiceResponse UpdateWorkout(int id, WorkoutCreateDto workoutDto, int userId)
    {
        var result = UpdateWorkoutAction(id, workoutDto, userId);
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
            Message = "Antrenamentul a fost modificat!"
        };
    }

    //DELETE (D)
    public ServiceResponse DeleteWorkout(int id)
    {
        var result = DeleteWorkoutAction(id);
        if (result == false)
        {
            return new ServiceResponse 
            {
                IsSuccess = false, 
                Message = "Antrenamentul nu a putut fi găsit (Id invalid)."
            };
        }

        return new ServiceResponse 
        {
            IsSuccess = true, 
            Message = "Antrenamentul a fost șters permanent!"
        };
    }

}

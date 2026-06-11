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
                Message = "Failed to save the workout."
            };
        }
        
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Workout saved successfully."
        };
    }
    
    //READ BY ID (R)
    public ServiceResponse GetWorkoutById(int id, int userId)
    {
        var workout = GetWorkoutByIdAction(id, userId);
        if (workout == null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Workout not found or access denied."
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
                Message = "Failed to update workout (invalid id?)."
            };
        }

        return new ServiceResponse 
        {
            IsSuccess = true, 
            Message = "Workout updated successfully."
        };
    }

    //DELETE (D)
    public ServiceResponse DeleteWorkout(int id, int userId)
    {
        var result = DeleteWorkoutAction(id, userId);
        if (result == false)
        {
            return new ServiceResponse 
            {
                IsSuccess = false, 
                Message = "Workout not found or access denied."
            };
        }

        return new ServiceResponse 
        {
            IsSuccess = true, 
            Message = "Workout deleted successfully."
        };
    }

}

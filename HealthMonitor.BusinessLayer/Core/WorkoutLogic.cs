using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Core;

public class WorkoutLogic : WorkoutActions, IWorkoutLogic
{
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

    public ServiceResponse GetWorkoutList()
    {
        return new ServiceResponse
        {
            IsSucces = true,
            Data = GetWorkoutListAction()
        };
    }
}

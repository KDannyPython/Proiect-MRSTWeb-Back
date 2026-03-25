using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IWorkoutLogic
{
    ServiceResponse CreateWorkout(WorkoutCreateDto workout);
    ServiceResponse GetWorkoutById(int id);
    ServiceResponse GetWorkoutList();
}
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IWorkoutLogic
{
    ServiceResponse CreateWorkout(WorkoutCreateDto workoutDto);
    ServiceResponse GetWorkoutById(int id);
    ServiceResponse GetWorkoutList();
    ServiceResponse UpdateWorkout(int id, WorkoutCreateDto workoutDto);
    ServiceResponse DeleteWorkout(int id);
}
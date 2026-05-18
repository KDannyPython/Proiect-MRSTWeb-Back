using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IWorkoutLogic
{
    ServiceResponse CreateWorkout(WorkoutCreateDto workoutDto, int userId);
    ServiceResponse GetWorkoutById(int id);
    ServiceResponse GetWorkoutList(int userId);
    ServiceResponse UpdateWorkout(int id, WorkoutCreateDto workoutDto, int userId);
    ServiceResponse DeleteWorkout(int id);
}
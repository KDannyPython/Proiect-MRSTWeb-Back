using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IWorkoutLogic
{
    ServiceResponse CreateWorkout(WorkoutCreateDto workoutDto, string username);
    ServiceResponse GetWorkoutById(int id);
    ServiceResponse GetWorkoutList(string username);
    ServiceResponse UpdateWorkout(int id, WorkoutCreateDto workoutDto, string username);
    ServiceResponse DeleteWorkout(int id);
}